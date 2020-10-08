using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EternityStore.Data.Model
{
    public class User
    {
     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        public string Zip { get; set; }

        public string Gender { get; set; }

        //public DateTime DateOfBirth { get; set; }

        public DateTime Created { get; set; }

        public ICollection<UserPhoto> UserPhotos { get; set; }




    }
}