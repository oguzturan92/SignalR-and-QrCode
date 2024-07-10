using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.ContactDto;
using WebUI.Dtos.SocialMediaDto;

namespace WebUI.ViewComponents.UIHome
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FooterViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/SocialMedia");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                ViewBag.socialMedias = values;
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7227/api/Contact/GetFirstContact");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetFirstContactDto>(jsonData);
                return View(value);
            }

            return View();
        }
    }
}