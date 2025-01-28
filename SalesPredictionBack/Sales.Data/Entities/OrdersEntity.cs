using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sales.Data.Entities
{
    [Table("Orders")]
    public class OrdersEntity
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Customers")]
        public int CustId { get; set; }
        public CustomersEntity? Customers { get; set; }

        [ForeignKey("Employees")]
        public int EmpId { get; set; }
        public EmployeesEntity Employees { get; set; }

        [ForeignKey("Shippers")]
        public int ShipperId { get; set; }
        public ShippersEntity Shippers { get; set; }

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
    }
}
