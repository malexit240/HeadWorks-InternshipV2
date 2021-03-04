using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Acr.UserDialogs;
using HWInternshipProject.Services;
using HWInternshipProject.Services.Validators;
using HWInternshipProject.Services.Models;

namespace HWInternshipProject.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        private string _login = "";
        private string _password = "";
        private string _confirm_password = "";
        private bool _hasLongActivity = false;

        private IUserService _userService;
        private ILoginValidatorService _loginValidator;
        private IPasswordValidatorService _passwordValidator;

        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public string ConfirmPassword
        {
            get => _confirm_password;
            set => SetProperty(ref _confirm_password, value);
        }

        public bool HasLongActivity
        {
            get => _hasLongActivity;
            set => SetProperty(ref _hasLongActivity, value);
        }

        public DelegateCommand SignUpCommand { get; set; }

        private async void SignUp()
        {
            await Task.Run(async () =>
            {
                
            });

        }

        public SignUpViewModel(INavigationService navigationService, ILoginValidatorService loginValidator, IPasswordValidatorService passwordValidator, IUserService userService) :
            base(navigationService)
        {
            _loginValidator = loginValidator;
            _passwordValidator = passwordValidator;
            _userService = userService;

            SignUpCommand = new DelegateCommand(async () =>
               {

                   if (Password != ConfirmPassword)
                   {
                       UserDialogs.Instance.Alert(TextResources["PasswordConfirmDontMatch"], TextResources["Error"], TextResources["Ok"]);
                       return;
                   }

                   switch (_passwordValidator.IsPasswordValid(Password))
                   {
                       case PasswordValidationStatus.InvalidLength:
                           UserDialogs.Instance.Alert(TextResources["PasswordLengthInvalid"], TextResources["Error"], TextResources["Ok"]);
                           return;
                       case PasswordValidationStatus.InvalidContent:
                           UserDialogs.Instance.Alert(TextResources["PaswordContentInvalid"], TextResources["Error"], TextResources["Ok"]);
                           return;
                   }

                   switch (await _loginValidator.IsLoginValid(Login))
                   {
                       case LoginValidationStatus.InvalidLength:
                           UserDialogs.Instance.Alert(TextResources["LoginInvalidLengthError"], TextResources["Error"], TextResources["Ok"]);
                           return;
                       case LoginValidationStatus.StartsWithDigit:
                           UserDialogs.Instance.Alert(TextResources["LoginStartWithDigitError"], TextResources["Error"], TextResources["Ok"]);
                           return;
                       case LoginValidationStatus.LoginNotUnique:
                           UserDialogs.Instance.Alert(TextResources["LoginNotUniqueError"], TextResources["Error"], TextResources["Ok"]);
                           return;
                   }

                   _userService.SignUp(Login, Password);

                   await NavigationService.GoBackAsync(("Login", Login));
               }, () => Login.Length != 0 && Password.Length != 0 && ConfirmPassword.Length != 0);

            SignUpCommand.ObservesProperty(() => Login);
            SignUpCommand.ObservesProperty(() => Password);
            SignUpCommand.ObservesProperty(() => ConfirmPassword);
        }
    }
}
