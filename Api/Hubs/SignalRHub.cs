using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IBookingService _bookingService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public SignalRHub(IBookingService bookingService, ICategoryService categoryService, IProductService productService)
        {
            _bookingService = bookingService;
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task SendBookingCount()
        {
            var value = _bookingService.GetAll().Count();
            await Clients.All.SendAsync("ReceiveBookingCount", value);
        }

        public async Task SendCategoryCount()
        {
            var value = _categoryService.GetAll().Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }

        public async Task SendProductCount()
        {
            var value = _productService.GetAll().Count();
            await Clients.All.SendAsync("ReceiveProductCount", value);
        }
    }
}