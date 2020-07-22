using System.Collections.Generic;
using EternityStore.API.Models;

namespace EternityStore.API.Dtos
{
    public class ProductCategoryForDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PhotoUrl { get; set; }


        public ICollection<ProductCategoryPhotoForDetailDto> CategoryPhotos { get; set; }



    }
}