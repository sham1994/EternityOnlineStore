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
    }
}