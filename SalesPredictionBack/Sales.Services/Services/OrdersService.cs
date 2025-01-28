using AutoMapper;
using Sales.Data.Entities;
using Sales.DataAccess.Data;
using Sales.Services.DTOs;

namespace Sales.Services.Services
{
    public class OrdersService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly ApplicationDbContext context;
        private readonly IMapper _mapper;

        public OrdersService(UnitOfWork unitOfWork, ApplicationDbContext context, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Servicio que retorna lista de ordenes de un cliente
        /// </summary>
        /// <param name="customersId"> id del cliente a consultar</param>
        /// <returns></returns>
        public ResponseDTO<List<OrdersDTO>> GetOrders(int customersId)
        {
            var ordersResponse = new ResponseDTO<List<OrdersDTO>>(false, "success", null);
            var orders = unitOfWork.Crud<OrdersEntity>().Get(s => (s.CustId == customersId)).ToList();
            if (orders != null)
            {
                ordersResponse.Data = _mapper.Map<List<OrdersDTO>>(orders);
                ordersResponse.Result = true;
            }
            return ordersResponse;
        }

        /// <summary>
        /// Servicio para adicionar una nueva orden
        /// </summary>
        /// <param name="newOrder"> DTO de la nueva orden a crear</param>
        /// <returns ResponseDTO> Mensaje con el exito o fracaso de la operacion</returns>
        public ResponseDTO AddNewOrder(NewOrderDTO newOrder)
        {
            using var transaction = context.Database.BeginTransaction();
            {
                try
                {
                    var order = new OrdersEntity()
                    {
                        CustId = newOrder.CustId,
                        EmpId = newOrder.EmpId,
                        ShipperId = newOrder.ShipperId,
                        OrderDate = newOrder.OrderDate,
                        RequiredDate = newOrder.RequiredDate,
                        ShippedDate = newOrder.ShippedDate,
                        Freight = newOrder.Freight,
                        ShipName = newOrder.ShipName,
                        ShipAddress = newOrder.ShipAddress,
                        ShipCity = newOrder.ShipCity,
                        ShipCountry = newOrder.ShipCountry,
                    };
                    unitOfWork.Crud<OrdersEntity>().Create(order);
                    unitOfWork.SaveChanges();

                    var orderDetail = new OrderDetailsEntity()
                    {
                        OrderId = order.OrderId,
                        ProductId = newOrder.ProductId,
                        UnitPrice = newOrder.UnitPrice,
                        Qty = newOrder.Qty,
                        Discount = newOrder.Discount,
                    };
                    unitOfWork.Crud<OrderDetailsEntity>().Create(orderDetail);
                    unitOfWork.SaveChanges();
                    transaction.Commit();
                    return new ResponseDTO(true, "Order created successfully");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new ResponseDTO(false, ex.Message);
                }
            }
        }
    }
}
