using Microsoft.AspNetCore.Mvc;
using Sales.Services.DTOs;
using Sales.Services.Services;

namespace Sales_Date_Prediction.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ProductsService productsService;

        public ProductsController(ProductsService productsService) 
        {
            this.productsService = productsService;
        }

        /// <summary>
        /// Servicio que obtiene todos los productos
        /// </summary>
        /// <returns> Lista de todos los productos</returns>
        [HttpGet("getProducts")]
        public ResponseDTO<List<ProductsDTO>> GetProducts()
        {
            return productsService.GetProducts();
        }
    }
}
