using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using CRMFamaV2.Data;
using CRMFamaV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRMFamaV2.Controllers
{
    public class AdminController : BaseController
    {
        public AdminController(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        // GET: /<controller>/
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //private async Task<bool> IsExistAccount(AccountModel objLogin)
        //{
        //    var user = await _context.UserList.FirstOrDefaultAsync(e => e.email == objLogin.email && e.status);
        //    if (user != null)
        //    {
        //        var password = BC.Verify(objLogin.password, user.password);
        //        if (password)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        private async Task<bool> IsExistemail(AccountModel objLogin)
        {
            var user = await _context.UserList.FirstOrDefaultAsync(e => e.email == objLogin.email && e.status);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> IsCorrectPassword(AccountModel objLogin)
        {
            var user = await _context.UserList.FirstOrDefaultAsync(e => e.email == objLogin.email);
            var password = BC.Verify(objLogin.password, user?.password);
            return password;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountModel objLogin)

        {
            var a = BC.HashPassword("nguyenthianhhong");
            if (ModelState.IsValid)
            {
                //if (await IsExistAccount(objLogin))
                //{
                //    List<Claim> claims = new List<Claim>()
                //    {
                //        new Claim(ClaimTypes.NameIdentifier, objLogin.email),
                //        new Claim("OtherProperties","Example Role")
                //    };

                //    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //    AuthenticationProperties properties = new AuthenticationProperties()
                //    {
                //        AllowRefresh = true,
                //        IsPersistent = objLogin.loginStatus,
                //    };

                //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);

                //    return RedirectToAction("Index", "Home");
                //}

                if (await IsExistemail(objLogin) == false)
                {
                    ViewData["ValidateMessage"] = "Email không tồn tại!";
                    return View();
                }
                if (await IsCorrectPassword(objLogin) == false)
                {
                    ViewData["ValidateMessage"] = "Password chưa chính xác!";
                    return View();
                }
                if (await IsExistemail(objLogin) && await IsCorrectPassword(objLogin))
                {
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, objLogin.email),
                        new Claim("OtherProperties","Example Role")
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = objLogin.loginStatus,
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}

