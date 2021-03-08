using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using HWInternshipProject.Models;
using System.Threading.Tasks;
using System;

namespace HWInternshipProject.Services.Models
{
    /// <summary>
    /// Implements IProfileService interface
    /// </summary>
    public class ProfileService : IProfileService
    {
        IProfileManager _profileManager;

        public ProfileService(IProfileManager profileManager) => _profileManager = profileManager;

        public async Task<List<Profile>> GetProfilesForUser(Guid userId)
        {
            return await Task.Run(() =>
            {
                using (var context = new Context())
                {
                    return (from usr in context.users.Include(u => u.Profiles) where usr.UserId == userId select usr).First().Profiles;
                }
            });
        }

        public async Task<List<Profile>> GetProfilesForUser(User user)
        {
            return await GetProfilesForUser(user.UserId);
        }

        public void AddProfile(Profile profile) => _profileManager.Create(profile);

        public void UpdateProfile(Profile profile) => _profileManager.Update(profile);

        public void RemoveProfile(Profile profile) => _profileManager.Delete(profile);


    }
}
