using Microsoft.AspNetCore.Mvc;
using Sales.Services.DTOs;
using Sales.Services.Services;

namespace Sales_Date_Prediction.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly CustomersService customersService;

        public CustomersController(CustomersService customersService) 
        {
            this.customersService = customersService;
        }

        /// <summary>
        /// Servicio que obtiene el listado de clientes con su ultima orden
        /// y predicción de proxima fecha de envio
        /// </summary>
        /// <returns></returns>
        [HttpGet("getSalesPrediction")]
        public ResponseDTO<List<SalesPredictionDTO>> GetSalesPredictions(string? searchCompany)
        {
            return customersService.GetSalesDatePrediction(searchCompany);
        }
    }
}
