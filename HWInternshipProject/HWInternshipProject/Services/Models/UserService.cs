using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HWInternshipProject.Models;

namespace HWInternshipProject.Services.Models
{
    /// <summary>
    /// Implements IUserServiceInterface
    /// </summary>
    public class UserService : IUserService
    {
        IUserManager _userManager;
        public UserService(IUserManager userManager) => _userManager = userManager;


        public async Task<User> SignInAsync(string login, string password)
        {
            return await Task.Run(() =>
            {
                using (var context = new Context())
                {
                    var hashPasword = (from user in context.users where user.Login == login select user.HashPassword).FirstOrDefault();

                    if (RFCHasher.Verify(password, hashPasword ?? ""))
                    {
                        var user = (from usr in context.users.Include(u => u.Profiles) where usr.Login == login select usr).First();

                        User.Current = user;
                        return user;
                    }

                    return null;
                }
            }
            );
        }

        public void LogOut() => User.Current = null;

        public async void SignUp(string login, string password) => await _userManager.Create(login, password);

    }
}
