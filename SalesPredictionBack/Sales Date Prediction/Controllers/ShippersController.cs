﻿using Microsoft.AspNetCore.Mvc;
using Sales.Services.DTOs;
using Sales.Services.Services;

namespace Sales_Date_Prediction.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShippersController : Controller
    {
        private readonly UnitOfWork unitOfWork;
        private readonly ShippersService shippersService;

        public ShippersController(UnitOfWork unitOfWork, ShippersService shippersService)
        {
            this.unitOfWork = unitOfWork;
            this.shippersService = shippersService;
        }

        /// <summary>
        /// Servicio que obtiene todos los transportistas
        /// </summary>
        /// <returns> Lista de transportistas</returns>
        [HttpGet("getShippers")]
        public ResponseDTO<List<ShippersDTO>> GetShippers()
        {
            return shippersService.GetShippers();
        }
    }
}
