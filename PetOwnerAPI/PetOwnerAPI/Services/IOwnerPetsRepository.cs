using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetOwnerAPI.Entities;
using PetOwnerAPI.Models;

namespace PetOwnerAPI.Services
{
    //Repository is used to make use of different functions needed for GetOwner for example
    //not an Iaction rather return type of whats needed
    public interface IOwnerPetsRepository
    {
        //Get all owner information
        IEnumerable<Owner> GetOwners();
        IEnumerable<Owner> GetOwnersNoList();
        Owner GetSingleOwnerByID(int Id);

        //Owner modifications
        void CreateOwner(Owner owner);
        void UpdateOwner(int IdName, OwnerUpdateDto owner);
        void DeleteOwner(int ID);


        IEnumerable<PetInfos> GetAllPetsByOwnerID(int Id);
        PetInfos GetPetByPetID(int OwnerID, int PetID);

        void AddPetToOwner(int OwnerID, PetInfos petInfos);
        void EditPetInfo(int IdOwner, int PetId, PetInfoUpdateDto petInfoDto);
        void DeleteAPet(int IdOwner, int PetId);
        void Save();
    }
}
