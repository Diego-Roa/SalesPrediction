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

        [HttpGet("getSalesPrediction")]
        public ResponseDTO<List<SalesPredictionDTO>> GetSalesPredictions()
        {
            return customersService.GetSalesDatePrediction();
        }
    }
}
