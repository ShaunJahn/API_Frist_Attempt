using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetOwnerAPI.Models
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<PetInfoDto> PetInfos { get; set; } = new List<PetInfoDto>();
    }
}
