using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EternityStore.Entity
{
    public class OrderForDetailDto
    {

        public int OrderDetailId { get; set; }

        public int ProductId { get; set; }

        public int ProductQty { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal SubTotal { get; set; }
        public DateTime Created { get; set; }
    }
}
