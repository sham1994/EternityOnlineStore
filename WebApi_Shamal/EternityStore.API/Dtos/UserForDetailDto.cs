using System;
using System.Collections.Generic;
using EternityStore.API.Models;

namespace EternityStore.API.Dtos
{
    public class UserForDetailDto
    {
         public int Id { get; set; }
        public string Username { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }
        public string City { get; set; }

        public string Country { get; set; }

        public string Gender { get; set; }

        public int  Age { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public string PhotoUrl { get; set; }

        public ICollection<UserPhotoForDetailDto> UserPhotos { get; set; }

    }
}