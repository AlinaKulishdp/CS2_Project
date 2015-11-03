using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Permission : BaseEntity
    {
        public PermissionType Type { get; set; }

        [MinLength(3), MaxLength(120)]
        public string Name { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public Permission()
        {
            Roles = new List<Role>();
        }
    }
}
