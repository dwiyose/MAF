using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TransactionModel _obj)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7025/Transaction/Save", _obj);

             return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
