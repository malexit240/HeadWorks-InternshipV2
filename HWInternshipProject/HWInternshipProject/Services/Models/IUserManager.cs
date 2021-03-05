using System.Threading.Tasks;
using HWInternshipProject.Models;

namespace HWInternshipProject.Services.Models
{
    public interface IUserManager
    {
        IUserManager Instance { get; }

        Task<User> Create(string login, string password);
        void Update();
        void Delete();
        Task<bool> IsLoginUnique(string login);
    }
}
