using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContactInfo: BaseEntity
    {
        [MinLength(3), MaxLength(25)]
        public string City { get; set; }

        [MinLength(3), MaxLength(100)]
        public string Adress { get; set; }

        [MinLength(3), MaxLength(15)]
        public string Telephone { get; set; }

        [MinLength(3), MaxLength(40)]
        public string Email { get; set; }
    }
}
