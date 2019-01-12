using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetOwnerAPI.Models
{
    public class PetInfoCreationDto
    {
        [Required(ErrorMessage = "Insert A Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insert A Type")]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required(ErrorMessage = "Insert A Description")]
        [MaxLength(50)]
        public string Description { get; set; }                                                                              
    }
}
