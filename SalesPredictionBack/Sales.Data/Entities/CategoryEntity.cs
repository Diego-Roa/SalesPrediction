using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Data.Entities
{
    public class CategoryEntity
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}
