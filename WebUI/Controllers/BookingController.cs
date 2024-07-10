using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.BookingDto;

namespace WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> BookingList()
        {
            ViewBag.bookingActive = "active";

            if (TempData["signalrActive"] != null)
            {
                Console.WriteLine(TempData["signalrActive"]);
            }

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult BookingCreate()
        {
            ViewBag.bookingActive = "active";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookingCreate(CreateBookingDto createBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7227/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                TempData["signalrActive"] = "true";
                return RedirectToAction("BookingList", "Booking");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BookingUpdate(int id)
        {
            ViewBag.bookingActive = "active";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/Booking/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetByIdBookingDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookingUpdate(UpdateBookingDto updateBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7227/api/Booking/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("BookingList", "Booking");
            }
            return View();
        }

        public async Task<IActionResult> BookingDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7227/api/Booking/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                TempData["signalrActive"] = "true";
                return RedirectToAction("BookingList", "Booking");
            }
            TempData["icon"] = "error";
            TempData["text"] = "İşlem başarısız.";
            return RedirectToAction("BookingList", "Booking");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> BookignCreateClient(Booking booking)
        {
            booking.BookingStatus = false;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(booking);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7227/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(jsonData);
            }
            return RedirectToAction("Index", "Booking");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            ViewBag.bookingIndex = "active";

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