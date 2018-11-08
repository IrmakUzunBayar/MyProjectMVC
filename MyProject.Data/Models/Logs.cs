using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Models
{
    public class Logs
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        [StringLength(128)]
        public string Level { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
    }
}
