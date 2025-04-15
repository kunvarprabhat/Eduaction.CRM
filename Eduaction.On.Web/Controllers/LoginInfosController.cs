using Eduaction.BusinessLogic.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Eduaction.On.Web.Controllers
{
    public class LoginInfosController : Controller
    {
        private readonly ILoginInfoRepository _loginRepo;

        public LoginInfosController(ILoginInfoRepository loginRepo)
        {
            _loginRepo = loginRepo;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this._loginRepo.GetAllLoginInfo();
            return View(result);
        }
       
    }
}
