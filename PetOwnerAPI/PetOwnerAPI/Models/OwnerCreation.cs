using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PetOwnerAPI.Entities;

namespace PetOwnerAPI.Models
{
    public class OwnerCreation
    {
        [Required(ErrorMessage = "Insert A Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insert A Surname")]
        [MaxLength(50)]
        public string Surname { get; set; }
    }
}

