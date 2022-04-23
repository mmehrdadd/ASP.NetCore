using ASP.NetCore.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCore.DTOs
{
    public class GenreCreationDTO
    {
       
        [Required]
        [FirstLetterUpperCase]
        [StringLength(40)]
        public string name { get; set; }
    }
}

