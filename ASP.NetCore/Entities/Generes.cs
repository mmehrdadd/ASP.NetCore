using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ASP.NetCore.Validations;
namespace ASP.NetCore.Entities
{
    public class Generes
    {
        [Key]
        public int id { get; set; }

        [Required]
        [FirstLetterUpperCase]
        [StringLength(40)]
        public string  name { get; set; }
    }
}
