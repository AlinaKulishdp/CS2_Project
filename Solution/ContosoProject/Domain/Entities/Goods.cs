using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Goods: BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string SKU { get; set; }

        [Required]
        public double Price { get; set; }

        public int Count { get; set; }

        public ProductCategory Category { get; set; }

        public virtual ICollection<Comment> Coments { get; set; }

        public Goods()
        {
            Coments = new List<Comment>();
            Category = new ProductCategory();
        }

    }
}
