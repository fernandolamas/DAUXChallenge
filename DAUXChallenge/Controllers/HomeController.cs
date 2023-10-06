using DauxChallengeCommon.Models;
using DauxChallengeService.Services.EncryptService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DAUXChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEncryptService _encryptService;

        public HomeController(IEncryptService encrypService)
        {
            _encryptService = encrypService;
        }

        public IActionResult Index()
        {
            var identity = new IdentityViewModel();
            return View(identity);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<ActionResult> Send(IdentityViewModel identity)
        {
            if(!ModelState.IsValid)
            {
                return View("Index", identity);
            }
            identity.Message = await _encryptService.EncryptAsync(identity);
            return View("Index", identity);
        }
    }
}