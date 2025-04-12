using Eduaction.BusinessLogic.Abstract;
using Eduaction.DataModel.DataModels;
using Eduaction.On.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Eduaction.On.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ILoginInfoRepository _loginRepo;
        public AccountController(IEmployeeRepository employeeRepo, ILoginInfoRepository loginRepo)
        {
            _employeeRepo = employeeRepo;
            _loginRepo = loginRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string loginId, string password)
        {
            var user =  _loginRepo.GetByLoginIdAsync(loginId);
            if (user != null && VerifyPasswordHash(password, user.Password))
            {
                HttpContext.Session.SetString("UserId", user.EmployeeId.ToString());
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Invalid login credentials.";
            return View();
        }

        

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // Simple method to verify password (you should use a proper hash in production)
        private bool VerifyPasswordHash(string enteredPassword, string storedPassword)
        {
            return enteredPassword == storedPassword; // Simplified logic, use proper hashing in real-world applications
        }

        // Simple password hashing function (use a better algorithm in production)
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
