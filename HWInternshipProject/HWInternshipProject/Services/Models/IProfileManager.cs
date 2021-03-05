using System;
using System.Threading.Tasks;
using HWInternshipProject.Models;

namespace HWInternshipProject.Services.Models
{
    public interface IProfileManager
    {
        Task<Profile> Create(Profile profile);
        Task<Profile> Create(Guid user_id, string nick, string name, string description = "", string imageDestination = "");
        Task Update(Profile profile);
        Task Delete(Profile profile);
    }
}
