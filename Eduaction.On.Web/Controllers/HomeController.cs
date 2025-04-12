using System.Diagnostics;
using System.Security.Claims;
using Eduaction.DataModel.DataModels;
using Eduaction.On.Web.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Eduaction.BusinessLogic.Abstract;

namespace Eduaction.On.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginInfoRepository _loginInfoRepository;
        
        public HomeController(ILoginInfoRepository loginInfoRepository,ILogger<HomeController> logger)
        {
            _loginInfoRepository = loginInfoRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Account");
            return View(new VMLogin());
            //return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(VMLogin modelLogin)
        {
            if (ModelState.IsValid)
            {
                var loginInfo = _loginInfoRepository.GetLoginInfoByUserIdPassword(modelLogin.LoginId, modelLogin.Password);
                if (loginInfo != null)
                {
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,loginInfo.Id.ToString()),
                         new Claim("FullName",loginInfo.FullName),
                         new Claim("EmailId",loginInfo.EmailId),
                         new Claim("MobileNo",loginInfo.MobileNo),
                         new Claim("CustomerId",loginInfo.CustomerId.ToString()),
                         new Claim("CustomerName",loginInfo.CustomerName),
                        new Claim("IsFirstLogin",loginInfo.IsFirstLogin.ToString()),
                        new Claim(ClaimTypes.Role,loginInfo.Role)
                    };
                    ClaimsIdentity claimIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = modelLogin.KeepLoggedIn,
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity), properties);
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ViewData["ErrorMsg"] = "User not found";
                }

            }
            else
            {
                ViewData["ErrorMsg"] = "Please enter valid data";
            }
            return View("Index", modelLogin);
        }
    }
}
