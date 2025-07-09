using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlogPostApplication.Models
{
    [Table("PostType")]


    public class PostType
    {
        [Key]
        public int PostTypeId { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }

        public List<Post> Posts { get; set; } 
    }

}

