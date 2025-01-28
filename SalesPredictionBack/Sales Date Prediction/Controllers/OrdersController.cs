using Microsoft.AspNetCore.Mvc;
using Sales.Services.DTOs;
using Sales.Services.Services;

namespace Sales_Date_Prediction.Controllers
{
    /// <summary>
    /// Controlador REST para gestionar ordenes
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly OrdersService ordersService;

        public OrdersController(OrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [HttpGet("getOrders/{customerId}")]
        public ResponseDTO<List<OrdersDTO>> GetOrders(int customerId) 
        {
            return this.ordersService.GetOrders(customerId);
        }

        [HttpPost("addOrder")]
        public ResponseDTO AddNewOrder(NewOrderDTO newOrder)
        {
            return this.ordersService.AddNewOrder(newOrder);
        }
    }
}
