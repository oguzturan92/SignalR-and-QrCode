using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.OrderDto;
using WebUI.Dtos.OrderLineDto;
using WebUI.Dtos.ProductDto;
using WebUI.Dtos.TableDto;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class TableOrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TableOrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> TableOrderList()
        {
            ViewBag.tableOrderActive = "active";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/TableOrder");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTableDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TableOrderDetail(int tableId, string tableTitle)
        {
            ViewBag.tableOrderActive = "active";
            ViewBag.tableId = tableId;
            ViewBag.tableTitle = tableTitle;
            Console.WriteLine(tableTitle);
            
            var model  = new TableOrderDetailModel()
            {
                Order = new ResultOrderAndOrderLineDto(){OrderId = 0},
                Products = new List<ResultProductWithCategoryDto>()
            };

            // products
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/Product/GetProductsWithCategoryStatusTrue");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                model.Products = values;
            }

            // OrderAndOrderLine
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7227/api/TableOrder/" + tableId);
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultOrderAndOrderLineDto>(jsonData);
                model.Order = value;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> TableOrderLineAdd(int tableId, int orderId, string productName, decimal productPrice, int productCount, string tableName)
        {
            if (orderId > 0)
            {
                var client1 = _httpClientFactory.CreateClient();
                var responseMessage1 = await client1.GetAsync("https://localhost:7227/api/Orderline/" + orderId + "," + productName);
                if (responseMessage1.IsSuccessStatusCode)
                {
                    var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                    var orderLine = JsonConvert.DeserializeObject<GetByIdOrderLineDto>(jsonData1);
                    
                    if (orderLine != null)
                    {
                        orderLine.ProductCount += productCount;

                        var client = _httpClientFactory.CreateClient();
                        var jsonData = JsonConvert.SerializeObject(orderLine);
                        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var responseMessage = await client.PutAsync("https://localhost:7227/api/Orderline/", stringContent);
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            TempData["icon"] = "success";
                            TempData["text"] = "Ürün eklendi.";
                        }
                    } else
                    {
                        var newOrderLine = new CreateOrderLineDto()
                        {
                            ProductName = productName,
                            ProductPrice = productPrice,
                            ProductCount = productCount,
                            OrderId = orderId
                        };

                        var client = _httpClientFactory.CreateClient();
                        var jsonData = JsonConvert.SerializeObject(newOrderLine);
                        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var responseMessage = await client.PostAsync("https://localhost:7227/api/Orderline", stringContent);
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            TempData["icon"] = "success";
                            TempData["text"] = "Ürün eklendi.";
                        }
                    }
                }
            } else
            {
                var order = new CreateOrderDto()
                {
                    TableId = tableId,
                    OrderTableNumber = tableName,
                    OrderComplate = false,
                    OrderDescription = "",
                    OrderDate = DateTime.Now,
                    OrderTotalPrice = 0
                };

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(order);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7227/api/Order", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["icon"] = "success";
                    TempData["text"] = "Ürün eklendi.";
                }
            }

            return RedirectToAction("TableOrderDetail", "TableOrder", new { tableId = tableId});
        }

        [HttpPost]
        public async Task<IActionResult> TableOrderLineOut(int tableId, int orderId, string productName)
        {

            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:7227/api/Orderline/" + orderId + "," + productName);
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var orderLine = JsonConvert.DeserializeObject<GetByIdOrderLineDto>(jsonData1);
                
                if (orderLine != null)
                {
                    if (orderLine.ProductCount > 1)
                    {
                        orderLine.ProductCount -= 1;

                        var client = _httpClientFactory.CreateClient();
                        var jsonData = JsonConvert.SerializeObject(orderLine);
                        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var responseMessage = await client.PutAsync("https://localhost:7227/api/Orderline/", stringContent);
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            TempData["icon"] = "success";
                            TempData["text"] = "Ürün çıkarıldı.";
                        }
                    } else
                    {
                        var client = _httpClientFactory.CreateClient();
                        var responseMessage = await client.DeleteAsync("https://localhost:7227/api/Orderline/" + orderLine.OrderLineId);
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            TempData["icon"] = "success";
                            TempData["text"] = "Ürün çıkarıldı.";
                        }
                    }
                }
            }

            return RedirectToAction("TableOrderDetail", "TableOrder", new { tableId = tableId});
        }

        [HttpPost]
        public async Task<IActionResult> TableOrderComplate(int orderId, decimal totalPrice)
        {
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:7227/api/Order/" + orderId);
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var order = JsonConvert.DeserializeObject<GetByIdOrderDto>(jsonData1);
                
                if (order != null)
                {
                    order.OrderTotalPrice = totalPrice;
                    order.OrderComplate = true;

                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(order);
                    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PutAsync("https://localhost:7227/api/Order/", stringContent);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        TempData["icon"] = "success";
                        TempData["text"] = "Adisyon kapatıldı";
                    }
                }
            }

            return RedirectToAction("TableOrderList", "TableOrder");
        }

    }
}