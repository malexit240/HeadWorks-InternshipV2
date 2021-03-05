using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HWInternshipProject.Models;

namespace HWInternshipProject.Services.Models
{
    public interface IProfileService
    {
        Task<List<Profile>> GetProfilesForUser(Guid userId);
        Task<List<Profile>> GetProfilesForUser(User user);
        void AddProfile(Profile profile);
        void UpdateProfile(Profile profile);
        void RemoveProfile(Profile profile);
    }
}
