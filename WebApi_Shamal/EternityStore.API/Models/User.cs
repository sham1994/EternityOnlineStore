using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EternityStore.API.Models
{
    public class User
    {
     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }
        public string City { get; set; }

        public string Country { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public ICollection<UserPhoto> UserPhotos { get; set; }




    }
}