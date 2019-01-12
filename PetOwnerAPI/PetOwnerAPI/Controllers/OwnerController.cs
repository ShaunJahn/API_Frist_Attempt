using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetOwnerAPI.Models;
using PetOwnerAPI.StaticDataStore;
using PetOwnerAPI.Services;
using PetOwnerAPI.Entities;
using AutoMapper;

namespace PetOwnerAPI.Controllers
{
    [Route("api/owners")]
    public class OwnerController : Controller
    {
        private ILogger<OwnerController> _logger;
        private IOwnerPetsRepository _OwnerRepos;

        public OwnerController(ILogger<OwnerController> logger, IOwnerPetsRepository repos)
        {
            _logger = logger;
            _OwnerRepos = repos;
        }

        [HttpGet("all")]
        public IActionResult GetOwners()
        {
            var OwnerEntities = _OwnerRepos.GetOwners();
            var results = new List<OwnerDto>();

            foreach (var OwnerEntity in OwnerEntities)
            {
                var pets = new List<PetInfoDto>();
                foreach (var pet in OwnerEntity.PetInfos)
                {
                    pets.Add(new PetInfoDto()
                    {
                        Id = pet.Id,
                        Name = pet.Description,
                        Description = pet.Description,
                        Type = pet.Type
                    });
                }
                results.Add(new OwnerDto()
                {
                    Id = OwnerEntity.Id,
                    Name = OwnerEntity.Name,
                    Surname = OwnerEntity.Surname,
                    PetInfos = pets
                });



            }
            return Ok(results);
        }

        [HttpGet("all/noDescription")]
        public IActionResult GetOwnersNoDescription()
        {
            var returnList = new List<OwnesWithoutCollectionDto>();
            var Owners = _OwnerRepos.GetOwnersNoList();
            foreach (var Owner in Owners)
            {
                returnList.Add(new OwnesWithoutCollectionDto()
                {
                    Id = Owner.Id,
                    Name = Owner.Name,
                    Surname = Owner.Surname
                });
            }

            return Ok(returnList);
        }

        [HttpGet("{Id}")]
        public IActionResult GetOwnerById(int Id)
        {
            var OwnerEntities = _OwnerRepos.GetSingleOwnerByID(Id);
            var results = new List<OwnerDto>();

            var pets = new List<PetInfoDto>();
            foreach (var pet in OwnerEntities.PetInfos)
            {
                pets.Add(new PetInfoDto()
                {
                    Id = pet.Id,
                    Name = pet.Description,
                    Description = pet.Description,
                    Type = pet.Type
                });
            }
            results.Add(new OwnerDto()
            {
                Id = OwnerEntities.Id,
                Name = OwnerEntities.Name,
                Surname = OwnerEntities.Surname,
                PetInfos = pets
            });


            return Ok(results);
        }


        [HttpPost("add")]
        public IActionResult OwnerCreate([FromBody] OwnerCreation ownerCreation)
        {
            var newOwner = new Owner()
            {
                Name = ownerCreation.Name,
                Surname = ownerCreation.Surname,
            };

            _OwnerRepos.CreateOwner(newOwner);
            return Ok(ownerCreation);
        }

        [HttpPut("{Id}/update")]
        public IActionResult OwnerUpdate(int Id, [FromBody] OwnerUpdateDto ownerUpdateDto)
        {
            _OwnerRepos.UpdateOwner(Id, ownerUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}/delete")]
        public IActionResult deleteOwner(int Id)
        {
            _OwnerRepos.DeleteOwner(Id);
            return Ok();
        }

        
    }
}
