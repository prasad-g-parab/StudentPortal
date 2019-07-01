using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    public class User
    {
        public User()
        {
        }

        [Key]
        public int id { get; set; }

        [DisplayName("firstName")]

        public string firstName { get; set; }

        [DisplayName("middlName")]
        public string middleName { get; set; }

        [DisplayName("lastName")]
        public string lastName { get; set; }

        [DisplayName("email")]
        public string email { get; set; }

        [DisplayName("password")]
        public string password { get; set; }

        [DisplayName("univercityId")]
        public string univercityId { get; set; }

        [DisplayName("collageId")]
        public string collageId { get; set; }

        [DisplayName("role")]
        public string role { get; set; }

    }
}
