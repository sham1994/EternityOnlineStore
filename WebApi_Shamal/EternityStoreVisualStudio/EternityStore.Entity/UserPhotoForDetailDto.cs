using System;

namespace EternityStore.Entity
{ 
    public class UserPhotoForDetailDto
    {
        public int Id { get; set; }

        public string Url { get; set; }
        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }
    }
}