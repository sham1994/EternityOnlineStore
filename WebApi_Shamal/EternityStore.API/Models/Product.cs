using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EternityStore.API.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public string Description { get; set; }

        public DateTime Created { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public int ProductCategoryId { get; set; }

        public ICollection<ProductPhoto> ProductPhotos { get; set; }
        
    }
}