using System;

namespace EternityStore.Data.Model
{ 
    public class UserPhoto
    {
        public int Id { get; set; }

        public string Url { get; set; }
        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }
}