using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.ViewModels
{
    public class UserDetailsVM
    {       
        public int UserDetailId { get; set; }        
        public string ApplicationUserId { get; set; }  
        [Display(Name ="Isim")]
        public string Name { get; set; }
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
    }
}
