using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.MessageDto;

namespace WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MessageList()
        {
            ViewBag.messageActive = "active";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/Message");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> MessageCreate(CreateMessageDto createMessageDto)
        {
            createMessageDto.MessageDate = DateTime.Now;
            createMessageDto.MessageRead = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7227/api/Message", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(jsonData);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MessageUpdate(int id)
        {
            ViewBag.messageActive = "active";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/Message/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetByIdMessageDto>(jsonData);

                // value.MessageRead = true;
                // var jsonData2 = JsonConvert.SerializeObject(value);
                // var stringContent2 = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                // var responseMessage2 = await client.PutAsync("https://localhost:7227/api/Message/", stringContent2);

                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MessageUpdate(UpdateMessageDto updateMessageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateMessageDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7227/api/Message/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("MessageList", "Message");
            }
            return View();
        }

        public async Task<IActionResult> MessageDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7227/api/Message/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                TempData["signalrActive"] = "true";
                return RedirectToAction("MessageList", "Message");
            }
            TempData["icon"] = "error";
            TempData["text"] = "İşlem başarısız.";
            return RedirectToAction("MessageList", "Message");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            ViewBag.messageIndex = "active";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/Slider/GetFirstSliderImage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.sliderImageFirst = jsonData;
            }
            return View();
        }
    }
}