using System;

namespace EternityStore.Entity
{
    public class ProductPhotoForDetailDto
    {
        public int Id { get; set; }

        public string Url { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
    }
}