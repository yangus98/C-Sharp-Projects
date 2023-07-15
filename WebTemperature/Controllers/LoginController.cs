using Microsoft.AspNetCore.Mvc;
using WebTemperature.Models;

namespace WebTemperature.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel lvm)
        {
            if (lvm.Fahrenheit != 0)
            {
                ViewBag.Messaggio = $"La temperatura equivalente in celsius è:  {Math.Round(((lvm.Fahrenheit - 32) * 5 / 9), 2)}°";
            }
            else
            {
                ViewBag.Messaggio = "Inserisci un numero diverso da 0!!!";
            }

            return View();
        }
    }
}
