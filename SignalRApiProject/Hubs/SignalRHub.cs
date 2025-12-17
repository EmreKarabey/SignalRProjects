using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.SignalR;

namespace SignalRApiProject.Hubs
{

    public class SignalRHub : Hub
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IProductsServices _productsServices;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTablesServices _menuTablesServices;
        private readonly IBookingServices _bookingServices;
        private readonly INotificationServices _notificationServices;
        public static int clientcount { get; set; } = 0;

        public SignalRHub(ICategoryServices categoryServices, IProductsServices productsServices, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTablesServices menuTablesServices,IBookingServices bookingServices,INotificationServices notificationServices)
        {
            _categoryServices = categoryServices;
            _productsServices = productsServices;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTablesServices = menuTablesServices;
            _bookingServices = bookingServices;
            _notificationServices = notificationServices;
        }

        public async Task SendStatics()
        {
            var values = _categoryServices.CategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", values);

            var values2 = _productsServices.ProductsCount();
            await Clients.All.SendAsync("RProductsCount", values2);


            var values3 = _categoryServices.ActiveCategory();
            await Clients.All.SendAsync("RActiveCount", values3);

            var values4 = _categoryServices.PassiveCategory();
            await Clients.All.SendAsync("RPassiveCount", values4);

            var values5 = _productsServices.HighPriceProduct();
            await Clients.All.SendAsync("RHighPrice", values5);

            var values6 = _productsServices.LowPriceProduct();
            await Clients.All.SendAsync("RLowPrice", values6);

            var values7 = _orderService.LastOrderPrice();
            await Clients.All.SendAsync("RLastOrder", values7.ToString("0.00"));

            var values8 = _moneyCaseService.SumCase();
            await Clients.All.SendAsync("RSumCase", values8.ToString("0.00"));


            var values9 = _bookingServices.GetList();
            await Clients.All.SendAsync("BookingList", values9);
        }


        public async Task SendProgressBar()
        {
            var values8 = _moneyCaseService.SumCase();
            await Clients.All.SendAsync("RSumCase", values8.ToString("0.00"));

            var values3 = _categoryServices.ActiveCategory();
            await Clients.All.SendAsync("RActiveCount", values3);

            var values = _menuTablesServices.MenuTableCount();
            await Clients.All.SendAsync("RTableCount", values);
        }

        public async Task Booking()
        {
            var values9 = _bookingServices.GetList();
            await Clients.All.SendAsync("BookingList", values9);
        }


        public async Task Notification()
        {
            var values = _notificationServices.NotificationCount();
            await Clients.All.SendAsync("NotificationCounts",values);

            var values2 = _notificationServices.GetList();
            await Clients.All.SendAsync("NotificatonList",values2);
        }

        public async Task MenuTablesList()
        {
            var values = _menuTablesServices.GetList();
            await Clients.All.SendAsync("MenuTablesList0",values);
        }

        public async Task ClientsMessage(string user, string message)
        {
            await Clients.All.SendAsync("ClientMessage00",user,message);
        }

        public async override Task OnConnectedAsync()
        {
            clientcount++;

            await Clients.All.SendAsync("ReceiveClientsCount",clientcount);

            await base.OnConnectedAsync();
        }

        public async override Task OnDisconnectedAsync(Exception? exception)
        {
            clientcount--;

            await Clients.All.SendAsync("ReceiveClientsCount",clientcount);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
