using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PetOwnerAPI.Entities
{
    public class OwnerPetsContext : DbContext
    {

        //create database
        public OwnerPetsContext(DbContextOptions<OwnerPetsContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.Migrate();
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetInfos> PetInfos { get; set; }
     }

   
}
