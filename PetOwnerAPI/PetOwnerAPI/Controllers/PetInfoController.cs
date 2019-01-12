using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetOwnerAPI.StaticDataStore;
using PetOwnerAPI.Models;
using PetOwnerAPI.Entities;
using PetOwnerAPI.Services;
using AutoMapper;

namespace PetOwnerAPI.Controllers
{
    [Route("api/owners")]
    public class PetInfoController : Controller
    {
        public OwnerPetsContext _Owner;
        private IOwnerPetsRepository _Context;

        public PetInfoController(OwnerPetsContext ownerPetsContext, IOwnerPetsRepository ownerPetsRepository)
        {
            _Owner = ownerPetsContext;
            _Context = ownerPetsRepository;
        }

        [HttpGet("database")]
        public IActionResult Database()
        {
            return Ok();
        }

        [HttpGet("{Id}/PetInfo")]
        public IActionResult GetPets(int Id)
        {
            var PetInfo = _Context.GetAllPetsByOwnerID(Id);
            var PetInfoMap = Mapper.Map<IEnumerable<PetInfoDto>>(PetInfo);
            return Ok(PetInfoMap);

        }

        [HttpGet("{OwnerId}/PetInfo/{PetId}", Name = "GetPets")]
        public IActionResult GetPetByPetID(int OwnerID, int PetID)
        {
            var GetPetByPetIDs = _Context.GetPetByPetID(OwnerID, PetID);
            var PetInfo = Mapper.Map<PetInfoDto>(GetPetByPetIDs);
            return Ok(GetPetByPetIDs);
        }

        [HttpPost("{Id}/PetInfo/add")]
        public IActionResult CreatePetForOwner(int Id, [FromBody] PetInfoCreationDto petInfoCreation )
        {
            var finalPetToAdd = Mapper.Map<PetInfos>(petInfoCreation);
            _Context.AddPetToOwner(Id, finalPetToAdd);

            return Ok();
            
        }

        [HttpPut("{OwnerId}/PetInfo/update/{PetId}")]
        public IActionResult PetUpdate(int OwnerId, int PetId, [FromBody] PetInfoUpdateDto petInfoUpdate)
        {
            _Context.EditPetInfo(OwnerId, PetId, petInfoUpdate);
            return Ok();
        }

        [HttpDelete("{id}/PetInfo/{petId}/delete")]
        public IActionResult DeletePet(int id, int petID)
        {
            _Context.DeleteAPet(id, petID);
            return Ok();
        }


    }


}