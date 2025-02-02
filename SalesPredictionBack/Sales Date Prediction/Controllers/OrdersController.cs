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

        /// <summary>
        /// Servicio que obtiene las ordenes de un cliente con su id
        /// </summary>
        /// <param name="customerId"> Id del cliente a consultar sus ordenes</param>
        /// <returns></returns>
        [HttpGet("getOrders/{customerId}")]
        public ResponseDTO<List<OrdersDTO>> GetOrders(int customerId) 
        {
            return this.ordersService.GetOrders(customerId);
        }

        /// <summary>
        /// Servicio para adicionar una nueva orden
        /// </summary>
        /// <param name="newOrder"> DTO con la nueva orden a adicionar</param>
        /// <returns></returns>
        [HttpPost("addOrder")]
        public ResponseDTO AddNewOrder(NewOrderDTO newOrder)
        {
            return this.ordersService.AddNewOrder(newOrder);
        }
    }
}
