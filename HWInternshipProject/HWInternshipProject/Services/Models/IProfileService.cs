using System.Collections.Generic;
using System;
using HWInternshipProject.Models;
using System.Threading.Tasks;

namespace HWInternshipProject.Services.Models
{
    public interface IProfileService
    {
        Task<List<Profile>> GetProfilesForUser(User user);
        void AddProfile(Profile profile);
        void UpdateProfile(Profile profile);
        void RemoveProfile(Profile profile);
    }
}
