using BookingSystem.Web.Models;
using BookingSystem.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookingSystem.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IApiService _apiService;

        public UsersController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                await _apiService.RegisterUserAsync(user);
                return RedirectToAction(nameof(Login));
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var token = await _apiService.LoginUserAsync(user);
                if (token != null)
                {

                    return RedirectToAction("Index", "Data");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(user);
        }
    }
}