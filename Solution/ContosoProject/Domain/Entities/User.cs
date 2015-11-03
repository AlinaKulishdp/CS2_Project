using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public PersonalInfo PersonalInfo { get; set; }

        public Role Role { get; set; }

        [MinLength(3), MaxLength(25)]
        public string Login { get; set; }

        [MinLength(5), MaxLength(40)]
        public string Password { get; set; }

        public User()
        {
            PersonalInfo = new PersonalInfo();
            Role = new Role();
        }
    }
}
