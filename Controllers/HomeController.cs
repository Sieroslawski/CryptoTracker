using CryptoTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoTracker.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        
        const string BASE_URL = "https://api.coingecko.com/api/v3/search";
        const string SINGLE_COIN_URL = "https://api.coingecko.com/api/v3/coins/";
        public bool GetError { get; private set; }
      

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {           
            try {
                               
                dynamic model = new ExpandoObject();

                var message = new HttpRequestMessage();
                message.Method = HttpMethod.Get;
                message.RequestUri = new Uri($"{BASE_URL}/trending");
                message.Headers.Add("Accept", "application/json");
                              
                var client = _clientFactory.CreateClient();
                var response = await client.SendAsync(message);
                
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var objResponse = JsonConvert.DeserializeObject<Trending>(responseContent);
                    model.Trend = objResponse.coins.ToList();
                    model.Search = "";
                   
                }                             

                return View(model);               
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(string CoinSearch)
        {
            try
            {
                dynamic model = new ExpandoObject();

                var searchMessage = new HttpRequestMessage();
                searchMessage.Method = HttpMethod.Get;
                searchMessage.RequestUri = new Uri($"{BASE_URL}?query={CoinSearch}");
                searchMessage.Headers.Add("Accept", "application/json");

                var clientSearch = _clientFactory.CreateClient();
                var responseSearch = await clientSearch.SendAsync(searchMessage);

                if (responseSearch.IsSuccessStatusCode)
                {
                    var responseContent = await responseSearch.Content.ReadAsStringAsync();
                    var objResponse = JsonConvert.DeserializeObject<Search>(responseContent);
                    model.Search = objResponse.coins.ToList();
                                     
                }

                return View(model);
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> GetCoin(string coinId)
        {
            dynamic model = new ExpandoObject();

            var coinMessage = new HttpRequestMessage();
            coinMessage.Method = HttpMethod.Get;
            coinMessage.RequestUri = new Uri($"{SINGLE_COIN_URL}{coinId}?localization=false&tickers=false&community_data=false&developer_data=false&sparkline=false");
            coinMessage.Headers.Add("Accept", "application/json");

            var clientSearch = _clientFactory.CreateClient();
            var responseSearch = await clientSearch.SendAsync(coinMessage);

            if (responseSearch.IsSuccessStatusCode)
            {
                var responseContent = await responseSearch.Content.ReadAsStringAsync();
                var objResponse = JsonConvert.DeserializeObject<SingleCoin>(responseContent);
               /* model.SingleCoin = objResponse.market_data.ToList();*/
            }
            return View(model);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
