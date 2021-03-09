using System;
using System.Linq;
using HWInternshipProject.Models;
using System.Threading.Tasks;

namespace HWInternshipProject.Services.Models
{
    /// <summary>
    /// Implements IUserManager interface
    /// </summary>
    public class UserManager : IUserManager
    {
        public IUserManager Instance { get => Instance != null ? Instance : Instance = new UserManager(); set => Instance = value; }

        public async Task<bool> IsLoginUnique(string login)
        {
            return await Task.Run(() =>
            {
                using (var context = new Context())
                {
                    return !context.Users.Any(u => u.Login == login);
                }
            });
        }

        public async Task<User> Create(string login, string password)
        {
            return await Task.Run(async () =>
            {
                using (var context = new Context())
                {

                    if (!await IsLoginUnique(login))
                        return null;

                    var user = new User()
                    {
                        UserId = Guid.NewGuid(),
                        Login = login,
                        HashPassword = RFCHasher.GetHash(password)
                    };

                    context.Users.Add(user);
                    context.SaveChanges();
                    return user;
                }
            });

        }

        public async void Update()
        {
            await Task.Run(() =>
            {
                using (var context = new Context())
                {
                    context.Users.Update(User.Current);
                    context.SaveChanges();
                }
            });
        }

        public async void Delete()
        {
            await Task.Run(() =>
            {
                using (var context = new Context())
                {
                    context.Users.Remove(User.Current);
                    context.SaveChanges();
                }
            });
        }
    }
}
