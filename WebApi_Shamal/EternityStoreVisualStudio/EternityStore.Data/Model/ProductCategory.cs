using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EternityStore.Data.Model
{
    public class ProductCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public ICollection<ProductCategoryPhoto> CategoryPhotos { get; set; }
    }
}