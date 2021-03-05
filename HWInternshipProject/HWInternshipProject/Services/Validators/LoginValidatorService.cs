using System;
using System.Threading.Tasks;
using HWInternshipProject.Services.Models;

namespace HWInternshipProject.Services.Validators
{
    public class LoginValidatorService : ILoginValidatorService
    {
        IUserManager _userManager;

        public LoginValidatorService(IUserManager userManager) => _userManager = userManager;

        public async Task<LoginValidationStatus> IsLoginValid(string login)
        {
            if (login.Length < 4 || login.Length > 16)
                return LoginValidationStatus.InvalidLength;

            if (Char.IsDigit(login[0]))
                return LoginValidationStatus.StartsWithDigit;

            if (!await _userManager.IsLoginUnique(login))
                return LoginValidationStatus.LoginNotUnique;

            return LoginValidationStatus.Valid;
        }
    }
}
