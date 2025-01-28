using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Data.Entities
{
    [Table("OrderDetails")]
    public class OrderDetailsEntity
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Qty { get; set; }

        public decimal Discount { get; set; }
    }
}
