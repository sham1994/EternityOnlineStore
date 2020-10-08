using System.Collections.Generic;


namespace EternityStore.Entity
{ 
    public class ProductForDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }

        public string PhotoUrl { get; set; }

        public ICollection<ProductPhotoForDetailDto> ProductPhotos { get; set; }
    }
}