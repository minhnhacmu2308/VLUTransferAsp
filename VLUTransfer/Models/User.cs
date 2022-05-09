using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VLUTransfer.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        [StringLength(255)]
        public string studentId { get; set; }

        [StringLength(255)]
        [Required]
        public string fullName { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string phoneNumber { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        public int status { get; set; }

        public virtual ICollection<Register> Registers { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}