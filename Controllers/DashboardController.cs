using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LibraryManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IConfiguration _config;

        public DashboardController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            var model = new DashboardModel();

            try
            {
                using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                connection.Open();

                model.TotalStudents = SafeCount(connection, "SELECT COUNT(*) FROM Students");
                model.TotalBooks = SafeCount(connection, "SELECT COUNT(*) FROM Books");
                model.TotalLibrarians = SafeCount(connection, "SELECT COUNT(*) FROM Librarians");
                model.TotalBorrowings = SafeCount(connection, "SELECT COUNT(*) FROM BorrowRecords");
                model.TotalPublications = SafeCount(connection, "SELECT COUNT(*) FROM Publications");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Could not connect to the database to load dashboard statistics.";
            }

            return View(model);
        }

        private int SafeCount(SqlConnection connection, string query)
        {
            try
            {
                using var cmd = new SqlCommand(query, connection);
                var result = cmd.ExecuteScalar();
                return result != null ? (int)result : 0;
            }
            catch
            {
                // Table might not exist yet (e.g. Students/Librarians before running setup.sql)
                return 0;
            }
        }
    }
}
