using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EternityStore.Data.Model
{ 
    public class ProductCategoryPhoto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int Id { get; set; }

        public string Url { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public int ProductCategoryId { get; set; }
    }
}