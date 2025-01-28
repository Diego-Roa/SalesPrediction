using AutoMapper;
using Sales.Data.Entities;
using Sales.DataAccess.Data;
using Sales.Services.DTOs;

namespace Sales.Services.Services
{
    public class ProductsService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly ApplicationDbContext context;
        private readonly IMapper _mapper;

        public ProductsService(UnitOfWork unitOfWork, ApplicationDbContext context, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.context = context;
            _mapper = mapper;
        }

        public ResponseDTO<List<ProductsDTO>> GetProducts()
        {
            var productsResponse = new ResponseDTO<List<ProductsDTO>>(false, "success", null);
            var products = unitOfWork.Crud<ProductsEntity>().GetAll().ToList();
            if (products != null)
            {
                productsResponse.Data = _mapper.Map<List<ProductsDTO>>(products);
                productsResponse.Result = true;
            }
            return productsResponse;
        }
    }
}
