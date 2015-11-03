using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime EditTime { get; set; }

        public BaseEntity()
        {
            IsActive = true;
            EditTime = DateTime.Now;
        }
    }
}
