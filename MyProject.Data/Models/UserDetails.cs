using MyProject.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Models
{
    public class UserDetails
    {
        [Key]
        public int UserDetailId { get; set; }
        //[Required]
        //[StringLength(128)]
        //public string ApplicationUserId { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        //public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
