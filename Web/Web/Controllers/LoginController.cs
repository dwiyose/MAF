using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;
using Web.Models;

namespace Web.Controllers
{
    public class LoginController : BaseController
    {

        //private readonly IHttpClientFactory _httpClientFactory;
        public LoginController(IApiService apiService) : base(apiService)
        {
        }
        public IActionResult Login()
        {
            ClearLoginSession();
            return View();
        }
        public async Task<IActionResult> CheckLogin(ms_user _obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ClearLoginSession();
                    var userData = await _apiService.GetUserLogin(_obj.user_name, _obj.password);
                    ms_user user = JsonSerializer.Deserialize<ms_user>(userData);
                    if (!string.IsNullOrEmpty(user.user_name))
                    {
                        HttpContext.Session.SetString("username", user.user_name); //set session
                        await CurrentUser(user);
                        return RedirectToAction("Index", "Home");
                    }
                    return BadRequest("Email / Password is wrong");
                }
                catch (Exception ex)
                {
                    return BadRequest("Error");
                }
            }
            return RedirectToAction(nameof(Login));
        }


        public IActionResult Logout()
        {
            ClearLoginSession();
            return RedirectToAction("Login", "Login");
        }
    }
}
