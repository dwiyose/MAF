using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Transactions;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IApiService apiService) : base(apiService)
        {
        }

        public async Task<IActionResult> Index()
        {

            await GetSessionData();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransactionModel _obj)
        {
            var data = await _apiService.SaveTransaction(_obj);
            if (data.Any())
            {
                // Set an alert message
                TempData["AlertMessage"] = "Data Berhasil Diinput.";
                TempData["AlertType"] = "alert-success"; // Optional: You can set alert type for styling
                                                         // await GetSessionData();
            }
           return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> List()
        {
            SetViewBags();
            var transaction = await _apiService.GetListTransaction();
            List<TransactionModel> trans = JsonConvert.DeserializeObject<List<TransactionModel>>(transaction);

            await GetSessionData();

            return View(trans);
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
