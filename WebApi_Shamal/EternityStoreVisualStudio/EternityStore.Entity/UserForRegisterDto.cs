using System;
using System.ComponentModel.DataAnnotations;

namespace EternityStore.Entity
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(8, MinimumLength=4, ErrorMessage = "You must specify  password between 4 and 8 characters")]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        public string Zip { get; set; }

        public string Gender { get; set; }

        public DateTime Created { get; set; }


    }
}