using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Request
{
    
    public class Category 
    {
        [Required]
        public int Id { get; set; } 
        public string  NameInEnglish { get; set; }
        public string NameIsHindi { get; set; }
    }
}
