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
        #region ---private Properties---
        private IUserService UserService { get; set; }
        private ILoginValidatorService LoginValidator { get; set; }
        private IPasswordValidatorService PasswordValidator { get; set; }
        #endregion

        #region ---Binable Properties---
        private string _login = "";
        private string _password = "";
        private string _confirm_password = "";
        private bool _hasLongActivity = false;


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
        #endregion

        #region ---Commands---
        public DelegateCommand SignUpCommand { get; set; }
        #endregion

        #region ---Constructors---
        public SignUpViewModel(INavigationService navigationService, ILoginValidatorService loginValidator, IPasswordValidatorService passwordValidator, IUserService userService) :
            base(navigationService)
        {
            LoginValidator = loginValidator;
            PasswordValidator = passwordValidator;
            UserService = userService;

            SignUpCommand = new DelegateCommand(async () =>
               {

                   if (Password != ConfirmPassword)
                   {
                       UserDialogs.Instance.Alert(TextResources["PasswordConfirmDontMatch"], TextResources["Error"], TextResources["Ok"]);
                       return;
                   }

                   switch (PasswordValidator.IsPasswordValid(Password))
                   {
                       case PasswordValidationStatus.InvalidLength:
                           UserDialogs.Instance.Alert(TextResources["PasswordLengthInvalid"], TextResources["Error"], TextResources["Ok"]);
                           return;
                       case PasswordValidationStatus.InvalidContent:
                           UserDialogs.Instance.Alert(TextResources["PaswordContentInvalid"], TextResources["Error"], TextResources["Ok"]);
                           return;
                   }

                   switch (await LoginValidator.IsLoginValid(Login))
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

                   UserService.SignUp(Login, Password);

                   await NavigationService.GoBackAsync(("Login", Login));
               }, () => Login.Length != 0 && Password.Length != 0 && ConfirmPassword.Length != 0);

            SignUpCommand.ObservesProperty(() => Login);
            SignUpCommand.ObservesProperty(() => Password);
            SignUpCommand.ObservesProperty(() => ConfirmPassword);
        }
        #endregion
    }
}
