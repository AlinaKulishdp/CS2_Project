using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PersonalInfo : BaseEntity
    {
        [MinLength(2), MaxLength(25)]
        public string FirstName { get; set; }

        [MinLength(2), MaxLength(25)]
        public string MiddleName { get; set; }

        [MinLength(2), MaxLength(25)]
        public string LastName { get; set; }
    }
}
