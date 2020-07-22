using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EternityStore.API.Models
{
    public class ProductPhoto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Url { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }






    }
}