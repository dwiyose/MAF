using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using Web.Models;

namespace Web.Controllers
{
    public class BaseController : Controller
    {

        public readonly IApiService _apiService;

        #region CONSTRUCTOR
        public string baseEmail;
        public string baseRoleCode;

        ms_user userLogin = new ms_user();
        public BaseController(IApiService apiService)
        {
            _apiService = apiService;
        }

        #endregion
        [HttpGet]
        public async Task<ms_user> CurrentUser(ms_user _obj)
        {
            if (!string.IsNullOrEmpty(_obj.user_name))
            {
                userLogin = _obj;
                SetViewBags();
            }

            //Model userLogin validation
            else 
            {
                _obj = null;
                HttpContext.Session.Clear();
                ViewData.Clear();
            }

            return userLogin;
        }
        public void SetViewBags()
        {
            ViewBag.username = HttpContext.Session.GetString("username");

        }
        public void ClearLoginSession()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                HttpContext.Session.Remove("username");
            }
        }
        public async Task GetSessionData()
        {
            SetViewBags();
            var locations = await _apiService.GetAllLocation();
            List<ms_location> locs = JsonConvert.DeserializeObject<List<ms_location>>(locations);
            ViewBag.Locations = locs;
        }
    }
}
