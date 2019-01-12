using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetOwnerAPI.Entities;
using PetOwnerAPI.Models;
using PetOwnerAPI.Services;

namespace PetOwnerAPI.ServiceImplementations
{
    public class OwnerPetsRepository : IOwnerPetsRepository
    {
        private OwnerPetsContext _Context;

        //create the link to DbCOntext
        public OwnerPetsRepository(OwnerPetsContext ownerPetsContext)
        {
            _Context = ownerPetsContext;
        }

        public void AddPetToOwner(int OwnerID, PetInfos petInfos)
        {
            var owner = GetSingleOwnerByID(OwnerID);
            owner.PetInfos.Add(petInfos);
            Save();
        }

        public void CreateOwner(Owner owner)
        {
            _Context.Add(owner);
            Save();
        }

        public void DeleteAPet(int IdOwner, int PetId)
        {
            var getOWnerPet = _Context.PetInfos.Where(c => c.OwnerId == IdOwner && c.Id == PetId).FirstOrDefault();
            _Context.Remove(getOWnerPet);
            Save();
        }

        public void DeleteOwner(int ID)
        {
            var getOWner = _Context.Owners.Where(c => c.Id == ID).FirstOrDefault();
            _Context.Remove(getOWner);
            Save();
        }

        public void EditPetInfo(int IdOwner, int PetId, PetInfoUpdateDto petInfoDto)
        {
            var updateOwnerPet = _Context.PetInfos.Where(c => c.OwnerId == IdOwner && c.Id == PetId).FirstOrDefault();
            _Context.Entry(updateOwnerPet).CurrentValues.SetValues(petInfoDto);
            Save();
        }

        public IEnumerable<PetInfos> GetAllPetsByOwnerID(int Id)
        {
            return _Context.PetInfos.Where(c => c.OwnerId == Id).ToList();
        }


        //using IEnumerable use ToList();
        public IEnumerable<Owner> GetOwners()
        {
            return _Context.Owners.Include(c => c.PetInfos).OrderBy(c => c.Name).ToList();
        }

        public IEnumerable<Owner> GetOwnersNoList()
        {
            return _Context.Owners.OrderBy(c => c.Name).ToList();
        }

        public Owner GetPetByOwnerID(int Id)
        {
            return _Context.Owners.Include(c => c.PetInfos).Where(c => c.Id == Id).FirstOrDefault();
        }

        public PetInfos GetPetByPetID(int OwnerID, int PetID)
        {
            return _Context.PetInfos.Where(o => o.OwnerId == OwnerID && o.Id == PetID).FirstOrDefault();
        }

        public Owner GetSingleOwnerByID(int Id)
        {
            return _Context.Owners.Where(c => c.Id == Id).Include(x => x.PetInfos).FirstOrDefault();
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

        public void UpdateOwner(int IdName, OwnerUpdateDto owner)
        {
            var updateOwner = _Context.Owners.Where(c => c.Id == IdName).FirstOrDefault();
            _Context.Entry(updateOwner).CurrentValues.SetValues(owner);
            Save();
        }
    }
}
