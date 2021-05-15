using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gallery.Models
{
    public class Post : BaseEntity
    {
        public Post()
        {
            Images = new List<Image>();
        }
        [Key]
        public int PostId { get; set; }
        [Required(ErrorMessage = "Comment is Required!")]
        public string Comment { get; set; }
       

        public ICollection<Image> Images { get; set; }
    }
}
