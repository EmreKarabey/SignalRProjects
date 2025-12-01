using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.SignalR;

namespace SignalRApiProject.Hubs
{

    //SignalR Dağıtım Yeri (Server)
    public class SignalRHub : Hub
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IProductsServices _productsServices;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTablesServices _menuTablesServices;

        public SignalRHub(ICategoryServices categoryServices, IProductsServices productsServices, IOrderService orderService, IMoneyCaseService moneyCaseService,IMenuTablesServices menuTablesServices)
        {
            _categoryServices = categoryServices;
            _productsServices = productsServices;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTablesServices = menuTablesServices;
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
        }


        public async Task SendProgressBar()
        {
            var values8 = _moneyCaseService.SumCase();
            await Clients.All.SendAsync("RSumCase", values8.ToString("0.00"));

            var values3 = _categoryServices.ActiveCategory();
            await Clients.All.SendAsync("RActiveCount", values3);

            var values = _menuTablesServices.MenuTableCount();
            await Clients.All.SendAsync("RTableCount",values);
        }

    }
}
