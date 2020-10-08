using System.ComponentModel.DataAnnotations.Schema;

namespace EternityStore.Data.Model
{
    public class OrderDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }

        public Product Product { get; set; }

        public int? ProductId { get; set; }

        public int? ProductQty { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? SubTotal { get; set; }
        public OrderHeader OrderHeader { get; set; }

        public int? OrderHeaderId { get; set; }


    }
}
