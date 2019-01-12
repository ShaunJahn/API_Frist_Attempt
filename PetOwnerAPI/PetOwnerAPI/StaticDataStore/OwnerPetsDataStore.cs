using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetOwnerAPI.Models;

namespace PetOwnerAPI.StaticDataStore
{
    public class OwnerPetsDataStore
    {
        public static OwnerPetsDataStore CurrentInfo = new OwnerPetsDataStore();
        public List<OwnerDto> OwnerPetInfo{ get; set; }

        public OwnerPetsDataStore()
        {
            //create list of OwnerPetInfo ,  init data set
            OwnerPetInfo = new List<OwnerDto>()
            {

                new OwnerDto()
                {
                    Id = 1,
                    Name = "Shaun",
                    Surname = "Mynhardt",
                    PetInfos = new List<PetInfoDto>()
                    {
                        new PetInfoDto()
                        {
                            Id = 1,
                            Name = "Zoe",
                            Type = "Chow",
                            Description = "Very active for her age"
                        },
                        new PetInfoDto()
                        {
                            Id = 2,
                            Name = "Misty",
                            Type = "Chow",
                            Description = "Naughty and slight agressive"
                        }
                    }
                },
                new OwnerDto()
                {
                    Id = 2,
                    Name = "Billy",
                    Surname = "Bob",
                    PetInfos = new List<PetInfoDto>()
                    {
                        new PetInfoDto()
                        {
                            Id = 3,
                            Name = "King Shark",
                            Type = "Pitbul",
                            Description = "AWesome pet to have :O!!"
                        }
                    }
                }
            };// end of dummy data
        }

    }
}
