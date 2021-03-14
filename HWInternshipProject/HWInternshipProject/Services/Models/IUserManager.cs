using System.Threading.Tasks;
using HWInternshipProject.Models;

namespace HWInternshipProject.Services.Models
{
    /// <summary>
    /// Defines interface for basic opertations with users
    /// </summary>
    public interface IUserManager
    {

        IUserManager Instance { get; }
        /// <summary>
        /// Creates and saves user in database
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>Saved user instance</returns>
        Task<User> Create(string login, string password);

        /// <summary>
        /// Updates current logged user in database
        /// </summary>
        void Update();

        /// <summary>
        /// Deletes current logged user in database
        /// </summary>
        void Delete();

        /// <summary>
        /// Checks whether login is unique
        /// </summary>
        /// <param name="login"></param>
        /// <returns>'True' if login unique and 'False' if login already exist</returns>
        Task<bool> IsLoginUnique(string login);
    }
}
