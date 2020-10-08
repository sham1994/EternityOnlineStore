using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EternityStore.Entity
{
    public class OrderForListDto
    {
        public int OrderHeaderId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OrderTotal { get; set; }

        public int UserId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        public string Zip { get; set; }

        public int TransectionId { get; set; }

        public DateTime OrderDateAndTime { get; set; }

        public ICollection<OrderForDetailDto> Orderdetails { get; set; }



    }
}
