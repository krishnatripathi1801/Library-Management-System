using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LibraryManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration _config;

        public StudentController(IConfiguration config)
        {
            _config = config;
        }

        // GET: Student?searchTerm=&page=
        public IActionResult Index(string? searchTerm, int page = 1)
        {
            var viewModel = new StudentIndexViewModel
            {
                SearchTerm = searchTerm,
                CurrentPage = page < 1 ? 1 : page
            };

            try
            {
                using var con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                con.Open();

                string searchCondition = "";
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    searchCondition = " WHERE Student_Name LIKE @Search OR Email LIKE @Search OR Phone_Number LIKE @Search";
                }

                // 1. Total count for pagination
                string countQuery = $"SELECT COUNT(*) FROM Students{searchCondition}";
                using (var countCmd = new SqlCommand(countQuery, con))
                {
                    if (!string.IsNullOrEmpty(searchTerm))
                        countCmd.Parameters.AddWithValue("@Search", $"%{searchTerm}%");

                    int totalRecords = (int)countCmd.ExecuteScalar();
                    viewModel.TotalPages = (int)Math.Ceiling((double)totalRecords / viewModel.PageSize);
                }

                if (viewModel.CurrentPage > viewModel.TotalPages && viewModel.TotalPages > 0)
                    viewModel.CurrentPage = viewModel.TotalPages;

                // 2. Paginated fetch
                int offset = (viewModel.CurrentPage - 1) * viewModel.PageSize;
                string dataQuery = $@"SELECT * FROM Students{searchCondition}
                                       ORDER BY StudentId
                                       OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                using var dataCmd = new SqlCommand(dataQuery, con);
                if (!string.IsNullOrEmpty(searchTerm))
                    dataCmd.Parameters.AddWithValue("@Search", $"%{searchTerm}%");
                dataCmd.Parameters.AddWithValue("@Offset", offset);
                dataCmd.Parameters.AddWithValue("@PageSize", viewModel.PageSize);

                using var reader = dataCmd.ExecuteReader();
                while (reader.Read())
                {
                    viewModel.Students.Add(new StudentModel
                    {
                        StudentId = (int)reader["StudentId"],
                        StudentName = reader["Student_Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone_Number"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while loading students. Make sure the Students table has been created (see Database/setup.sql).";
            }

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using var con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var cmd = new SqlCommand("INSERT INTO Students (Student_Name, Email, Phone_Number) VALUES (@Name, @Email, @Phone)", con);
            cmd.Parameters.AddWithValue("@Name", model.StudentName);
            cmd.Parameters.AddWithValue("@Email", model.Email);
            cmd.Parameters.AddWithValue("@Phone", model.Phone);
            con.Open();
            cmd.ExecuteNonQuery();

            TempData["SuccessMessage"] = "Student added successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student = new StudentModel();
            using var con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var cmd = new SqlCommand("SELECT * FROM Students WHERE StudentId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                student.StudentId = (int)reader["StudentId"];
                student.StudentName = reader["Student_Name"].ToString();
                student.Email = reader["Email"].ToString();
                student.Phone = reader["Phone_Number"].ToString();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(StudentModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using var con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var cmd = new SqlCommand("UPDATE Students SET Student_Name=@Name, Email=@Email, Phone_Number=@Phone WHERE StudentId=@id", con);
            cmd.Parameters.AddWithValue("@Name", model.StudentName);
            cmd.Parameters.AddWithValue("@Email", model.Email);
            cmd.Parameters.AddWithValue("@Phone", model.Phone);
            cmd.Parameters.AddWithValue("@id", model.StudentId);
            con.Open();
            cmd.ExecuteNonQuery();

            TempData["SuccessMessage"] = "Student updated successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            using var con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var cmd = new SqlCommand("DELETE FROM Students WHERE StudentId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();

            TempData["SuccessMessage"] = "Student deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
