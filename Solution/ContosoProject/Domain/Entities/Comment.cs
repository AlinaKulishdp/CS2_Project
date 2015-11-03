using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Comment : BaseEntity
    {
        [MaxLength(2000)]
        public string Message { get; set; }
        public CommentType Type { get; set; }
    }
}
