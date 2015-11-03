using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class Role : BaseEntity
    {      
        [MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }

        public Role() 
        { 
            Permissions = new List<Permission>(); 
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
