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
        private readonly IOrderService _orderService;
        private readonly IMessageService _messageService;
        private readonly ITableService _tableService;

        public SignalRHub(IBookingService bookingService, ICategoryService categoryService, IProductService productService, IOrderService orderService, IMessageService messageService, ITableService tableService)
        {
            _bookingService = bookingService;
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _messageService = messageService;
            _tableService = tableService;
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

        public async Task SendBookingCount()
        {
            var value = _bookingService.GetAll().Count();
            await Clients.All.SendAsync("ReceiveBookingCount", value);
            await Clients.All.SendAsync("NotificationBooking");
        }

        public async Task SendOrderCount()
        {
            var value = _orderService.GetAll().Count();
            await Clients.All.SendAsync("ReceiveOrderCount", value);
        }

        public async Task SendMessageCount()
        {
            var value = _messageService.GetAll().Count();
            await Clients.All.SendAsync("ReceiveMessageCount", value);
            await Clients.All.SendAsync("NotificationMessage");
        }

        public async Task SendTableIsFullChange(int tableId)
        {
            var value = _tableService.GetById(tableId);
            if (value.TableIsItFull)
            {
                value.TableIsItFull = false;
            } else
            {
                value.TableIsItFull = true;
            }
            _tableService.Update(value);
            await Clients.All.SendAsync("ReceiveTableIsFullChange", value.TableId);
        }

        public async Task SendActiveTableCount()
        {
            var value = _tableService.GetAll().Where(x => x.TableIsItFull).Count();
            await Clients.All.SendAsync("ReceiveActiveTableCount", value);
        }
    }
}