using AutoMapper;
using Sales.Data.Entities;
using Sales.DataAccess.Data;
using Sales.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services.Services
{
    public class ShippersService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly ApplicationDbContext context;
        private readonly IMapper _mapper;

        public ShippersService(UnitOfWork unitOfWork, ApplicationDbContext context, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los transportistas.
        /// </summary>
        /// <returns>Una lista de transportistas</returns>
        public ResponseDTO<List<ShippersDTO>> GetShippers()
        {
            var shippersResponse = new ResponseDTO<List<ShippersDTO>>(false,"success", null);
            var shippers = unitOfWork.Crud<ShippersEntity>().GetAll().ToList();
            if (shippers != null)
            {
                shippersResponse.Data = _mapper.Map<List<ShippersDTO>>(shippers);
                shippersResponse.Result = true;
            }
            return shippersResponse;
        }
    }
}
