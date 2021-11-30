using BookShop.Heplers;
using BookShop.Heplers.EmailSender;
using BookShop.Models;
using BookShop.Report;
using BookShop.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        private readonly IPurchaseHistoryService _purchaseHistory;

        public AccountController(IAccountService service, IPurchaseHistoryService purchaseHistory)
        {
            _service = service;
            _purchaseHistory = purchaseHistory;
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> SendOrderConfirmation()
        {
            EmailSender email = new EmailSender(new EmailParams
            {
                HostSmpt = "smpt.gmail.com",
                Port = 587,
                EnableSsl = true,
                SenderName = "Olek Solich",
                SenderEmail = "bookshopappsolo@gmail.com",
                SenderEmailPassword = "nethdnetzacnntub"
            });

            await email.Send("bookshopappsolo@gmail.com", "Test", "To jest testowa wiadomość");

            return RedirectToAction(nameof(Info));
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult GetPDF()
        {
            PurchaseHistoryReport report = new PurchaseHistoryReport();
            byte[] abytes = report.PrepareReport(_purchaseHistory.Get());
            return File(abytes, "application/pdf");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginUser, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMassage = "Invalid login or password!";
                return View();
            }


            UpdateUserViewModel user = _service.Login(loginUser.Email, loginUser.Password);
            if (user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                if (user.Name is null)
                    claims.Add(new Claim(ClaimTypes.Name, user.Email));
                else
                    claims.Add(new Claim(ClaimTypes.Name, user.Name));

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Login");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return Redirect(ReturnUrl == null ? "/Book" : ReturnUrl);
            }
            else
            {
                ViewBag.ErrorMassage = "Invalid login or password!";
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Home", "Book");
        }

        [Authorize]
        public IActionResult Info()
        {
            var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            return View(_service.GetUser(email.Value));
        }

        [Authorize]
        public IActionResult Update()
        {
            var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            return View(_service.GetUserToUpdate(email.Value));
        }

        [HttpPost]
        public IActionResult Update(UpdateUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if(files.Any())
                    user.Picture = FileConverter.ConverToByte(files[0]);
                _service.UpdateUser(user);
                return RedirectToAction(nameof(Info));
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if(files.Any())
                    user.Picture = FileConverter.ConverToByte(files[0]);
                _service.AddUser(user);
                return RedirectToAction(nameof(Login));
            }

            return View();
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult ListOfUsers(string phrase)
        {
            return View(_service.GetUsers(phrase));
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult GiveRole(int id)
        {
            return View(_service.GetUser(id));
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult GiveRolePost(int id)
        {
            _service.GiveRole(id);
            return RedirectToAction(nameof(ListOfUsers));
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult TakeRole(int id)
        {
            return View(_service.GetUser(id));
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult TakeRolePost(int id)
        {
            _service.TakeRole(id);
            return RedirectToAction(nameof(ListOfUsers));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
