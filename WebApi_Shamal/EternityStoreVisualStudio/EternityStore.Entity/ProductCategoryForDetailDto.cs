using System.Collections.Generic;


namespace EternityStore.Entity
{
    public class ProductCategoryForDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PhotoUrl { get; set; }


        public ICollection<ProductCategoryPhotoForDetailDto> CategoryPhotos { get; set; }



    }
}