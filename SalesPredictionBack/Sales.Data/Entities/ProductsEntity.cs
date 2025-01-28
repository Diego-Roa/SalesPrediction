using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Data.Entities
{
    public class ProductsEntity
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        [ForeignKey("Suppliers")]
        public int SupplierId { get; set; }
        public SuppliersEntity Suppliers { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

        public decimal UnitPrice { get; set; }

        public Boolean Discontinued { get; set; }
    }
}
