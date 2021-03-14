using System.Threading.Tasks;
using HWInternshipProject.Models;

namespace HWInternshipProject.Services.Models
{
    /// <summary>
    /// Defines interface for logical operations with users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Authorizes user
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>User instance if login and password match. Else null</returns>
        Task<User> SignInAsync(string login, string password);


        /// <summary>
        /// Logouts current user
        /// </summary>
        void LogOut();

        /// <summary>
        /// Creates new user with login and password
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        void SignUp(string login, string password);
    }
}
