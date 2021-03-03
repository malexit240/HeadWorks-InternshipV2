using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using HWInternshipProject.Services;
using HWInternshipProject.Models;
using HWInternshipProject.Services.Validators;
using HWInternshipProject.Services.Models;

using HWInternshipProject.Resources;

using Acr.UserDialogs;

namespace HWInternshipProject.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        string _login = "";
        string _password = "";
        string _confirm_password = "";
        bool _hasLongActivity = false;

        public string Login
        {
            get { return _login; }
            set
            {
                SetProperty(ref _login, value);
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
            }
        }
        public string ConfirmPassword
        {
            get { return _confirm_password; }
            set
            {
                SetProperty(ref _confirm_password, value);
            }
        }

        public bool HasLongActivity
        {
            get => _hasLongActivity;
            set => SetProperty(ref _hasLongActivity, value);
        }

        public DelegateCommand SignUpCommand { get; set; }
        public SignUpViewModel(INavigationService navigationService, ILoginValidatorService loginValidator, IPasswordValidatorService passwordValidator, IUserService userService) :
            base(navigationService)
        {
            SignUpCommand = new DelegateCommand(async () =>
               {
                   if (Password != ConfirmPassword)
                   {
                       UserDialogs.Instance.Alert(TextResources.PasswordConfirmDontMatch, TextResources.Error, TextResources.Ok);
                       return;
                   }

                   switch (passwordValidator.IsPasswordValid(Password))
                   {
                       case PasswordValidationStatus.InvalidLength:
                           UserDialogs.Instance.Alert(TextResources.PasswordLengthInvalid, TextResources.Error, TextResources.Ok);
                           return;
                       case PasswordValidationStatus.InvalidContent:
                           UserDialogs.Instance.Alert(TextResources.PaswordContentInvalid, TextResources.Error, TextResources.Ok);
                           return;
                   }

                   switch (await loginValidator.IsLoginValid(Login))
                   {
                       case LoginValidationStatus.InvalidLength:
                           UserDialogs.Instance.Alert(TextResources.LoginInvalidLengthError, TextResources.Error, TextResources.Ok);
                           return;
                       case LoginValidationStatus.StartsWithDigit:
                           UserDialogs.Instance.Alert(TextResources.LoginStartWithDigitError, TextResources.Error, TextResources.Ok);
                           return;
                       case LoginValidationStatus.LoginNotUnique:
                           UserDialogs.Instance.Alert(TextResources.LoginNotUniqueError, TextResources.Error, TextResources.Ok);
                           return;
                   }

                   userService.SignUp(Login, Password);

                   await navigationService.GoBackAsync(("Login", Login));
               },() => Login.Length != 0 && Password.Length != 0 && ConfirmPassword.Length != 0);

            SignUpCommand.ObservesProperty(() => Login);
            SignUpCommand.ObservesProperty(() => Password);
            SignUpCommand.ObservesProperty(() => ConfirmPassword);
        }
    }
}
