using Sales.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services.DTOs
{
    public class NewOrderDTO
    {
        public int CustId { get; set; }

        public int EmpId { get; set; }

        public int ShipperId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public decimal Freight { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string? ShipRegion { get; set; }

        public string? ShipPostalcode { get; set; }

        public string? ShipCountry { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Qty { get; set; }

        public decimal Discount { get; set; }
    }
}
