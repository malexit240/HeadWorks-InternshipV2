using System.Threading.Tasks;
using HWInternshipProject.Models;

namespace HWInternshipProject.Services.Models
{
    public interface IUserService
    {
        Task<User> SignInAsync(string login, string password);
        void LogOut();
        void SignUp(string login, string password);
    }
}
