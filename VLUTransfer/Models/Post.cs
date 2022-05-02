using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VLUTransfer.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int postId { get; set; }

        [StringLength(255)]
        [Required]
        public string title { get; set; }

        [StringLength(255)]
        public string image { get; set; }
        public int userId { get; set; }
        public string description { get; set; }
        public int price { get; set; }

        public string createdAt { get; set; }
        public int status { get; set; }
        public virtual ICollection<Register> Registers { get; set; }
        public virtual User User { get; set; }
    }
}