using AutoMapper;
using Sales.Data.Entities;
using Sales.DataAccess.Data;
using Sales.Services.DTOs;

namespace Sales.Services.Services
{
    public class EmployeesService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly ApplicationDbContext context;
        private readonly IMapper _mapper;

        public EmployeesService(UnitOfWork unitOfWork, ApplicationDbContext context, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los empleados.
        /// </summary>
        /// <returns>Una lista de empleados</returns>
        public ResponseDTO<List<EmployeesDTO>> GetEmployees()
        {
            var employeesResponse = new ResponseDTO<List<EmployeesDTO>>(false, "success", null);
            var employees = unitOfWork.Crud<EmployeesEntity>().GetAll().ToList();
            if (employees != null)
            {
                employeesResponse.Data = _mapper.Map<List<EmployeesDTO>>(employees);
                employeesResponse.Result = true;
            }
            return employeesResponse;
        }
    }
}
