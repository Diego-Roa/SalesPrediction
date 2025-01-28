using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Data.Entities
{
    [Table("Customers")]
    public class CustomersEntity
    {
        [Key]
        public int CustId { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }

        public string Postalcode { get; set; }

        public string Phone { get; set; }

        public string? Fax { get; set; }
    }
}
