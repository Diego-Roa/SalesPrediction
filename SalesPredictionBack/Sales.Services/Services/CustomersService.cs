using Sales.DataAccess.Data;
using Sales.Services.DTOs;

namespace Sales.Services.Services
{
    public class CustomersService
    {
        private readonly ApplicationDbContext context;

        public CustomersService(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Servicio para obtener lista de clientes con su respectiva predicción
        /// </summary>
        /// <returns ResponseDTO> lista de clientes con prediccion de fecha</returns>
        public ResponseDTO<List<SalesPredictionDTO>> GetSalesDatePrediction(string? searchCompany)
        {
            var salesResponse = new ResponseDTO<List<SalesPredictionDTO>>(false, "success", null);
            var ordersGrouped = context.Orders
                .Join(context.Customers,
                order => order.CustId,
                customer => customer.CustId,
                (order, customer) => new { Order = order, Customer = customer})
                .GroupBy(o => new { o.Order.CustId, o.Customer.CompanyName})
                .Select(g => new
                {
                    CustId = g.Key.CustId,
                    Customer = g.Key.CompanyName,
                })
                .ToList();

            var data = new List<SalesPredictionDTO>();
            foreach (var i in ordersGrouped)
            {
                double allDays = 0;
                int difference = 0;

                DateTime[] dates = context
                     .Orders.Where(s => s.CustId == i.CustId)
                     .Select(s => s.OrderDate)
                     .ToArray();

                for (int d = 1; d < dates.Length; d++) 
                {                    
                    DateTime beforeDate = dates[d-1].Date;

                    DateTime currentDate = dates[d].Date;

                    allDays += (currentDate - beforeDate).TotalDays;
                    difference++;
                }
                double avg = difference > 0 ? allDays / difference : 0;
                DateTime predicterOrder = dates[dates.Length-1].AddDays(avg);

                var _data = new SalesPredictionDTO
                {
                    CustId = i.CustId,
                    LastOrderDate = dates[dates.Length-1],
                    NextPredicterOrder = predicterOrder,
                    CompanyName = i.Customer
                };
                data.Add(_data);
            }
            if (!String.IsNullOrEmpty(searchCompany))
            {
                data = data.Where(s => s.CompanyName.IndexOf(searchCompany, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            salesResponse.Data = data;
            salesResponse.Result = true;
            return salesResponse;
        }
    }
}
