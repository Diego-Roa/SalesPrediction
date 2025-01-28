using Microsoft.AspNetCore.Mvc;
using Sales.Services.DTOs;
using Sales.Services.Services;

namespace Sales_Date_Prediction.Controllers
{
    /// <summary>
    /// Controlador REST para gestionar empleados
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly UnitOfWork unitOfWork;
        private readonly EmployeesService employeesService;

        public EmployeesController(UnitOfWork unitOfWork, EmployeesService employeesService)
        {
            this.unitOfWork = unitOfWork;
            this.employeesService = employeesService;
        }

        [HttpGet("getEmployees")]
        public ResponseDTO<List<EmployeesDTO>> GetEmployees()
        {
            return employeesService.GetEmployees();
        }
    }
}
