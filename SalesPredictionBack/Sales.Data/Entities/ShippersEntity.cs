using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Data.Entities
{
    public class ShippersEntity
    {
        [Key]
        public int ShipperId { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }
    }
}
