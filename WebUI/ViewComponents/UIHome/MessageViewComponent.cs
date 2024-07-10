using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UIHome
{
    public class MessageViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MessageViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("https://localhost:7227/api/Contact/GetFirstContactMapUrl");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.mapUrl = jsonData;
            }
            return View();
        }
    }
}