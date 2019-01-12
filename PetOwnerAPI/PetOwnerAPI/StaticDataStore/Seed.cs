using System;
using System.Collections.Generic;
using System.Linq;
using PetOwnerAPI.Entities;

namespace PetOwnerAPI
{
    public static class Seed
    {
        public static void EnsureSeedDataForContext(this OwnerPetsContext context)
        {
            if (context.Owners.Any())
            {
                return;
            }

            // init seed data
            var Owners = new List<Owner>()
            {
                new Owner()
                {
                    Name = "Shaun",
                    Surname = "Mynhardt",
                    PetInfos = new List<PetInfos>()
                    {
                        new PetInfos()
                        {
                            Name = "Zoe",
                            Type = "Chow",
                            Description = "Very active for her age"
                        },
                        new PetInfos()
                        {
                            Name = "Misty",
                            Type = "Chow",
                            Description = "Naughty and slight agressive"
                        },
                    }
                },
                new Owner()
                {
                    Name = "Billy",
                    Surname = "Bob",
                    PetInfos = new List<PetInfos>()
                    {
                        new PetInfos()
                        {
                            Name = "King Shark",
                            Type = "Pitbul",
                            Description = "AWesome pet to have :O!!"
                        }
                    }
                },
            };// end of dummy data
            context.Owners.AddRange(Owners);
            context.SaveChanges();
        }

    }
}
