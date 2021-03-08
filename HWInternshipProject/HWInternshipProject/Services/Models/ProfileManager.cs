using System;
using System.Threading.Tasks;
using HWInternshipProject.Models;

namespace HWInternshipProject.Services.Models
{
    /// <summary>
    /// Implements IProfileManager interface
    /// </summary>
    public class ProfileManager : IProfileManager
    {
        public async Task<Profile> Create(Profile profile)
        {
            return await Task.Run(() =>
            {
                using (var context = new Context())
                {
                    if (context.users.Find(profile.UserId) == null)
                        throw new NullReferenceException();

                    profile.CreationTime = DateTime.Now;

                    context.profiles.Add(profile);
                    context.SaveChanges();
                    profile.RaiseActualize();

                    return profile;
                }
            });
        }

        public async Task<Profile> Create(Guid user_id, string nick, string name, string description = "", string imageDestination = "")
        {
            return await Create(new Profile()
            {
                UserId = user_id,
                ImageDestination = imageDestination,
                NickName = nick,
                Name = name,
                Description = description,
            });
        }

        public async Task Update(Profile profile)
        {
            await Task.Run(() =>
            {
                using (var context = new Context())
                {
                    context.profiles.Update(profile);
                    context.SaveChanges();

                    profile.RaiseActualize();
                }
            });
        }

        public async Task Delete(Profile profile)
        {
            await Task.Run(() =>
            {
                using (var context = new Context())
                {
                    context.profiles.Remove(profile);
                    context.SaveChanges();
                    profile.RaiseActualize();
                }
            });
        }
    }
}
