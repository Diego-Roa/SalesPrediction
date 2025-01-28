using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services.DTOs
{
    public class SalesPredictionDTO
    {
        public int CustId { get; set; }

        public string? CompanyName { get; set; }

        public DateTime? LastOrderDate { get; set; }

        public DateTime NextPredicterOrder {  get; set; }
    }
}
