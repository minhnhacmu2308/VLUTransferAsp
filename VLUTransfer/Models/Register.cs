using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VLUTransfer.Models
{
    public class Register
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int registeId { get; set; }
        public int postId { get; set; }
        public int userId { get; set; }
        public string dateRegister { get; set; }
        public int status { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}