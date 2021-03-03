using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using HWInternshipProject.Models;
using HWInternshipProject.Services.Models;
using Acr.UserDialogs;
using HWInternshipProject.Resources;
using HWInternshipProject.Services.Settings;

namespace HWInternshipProject.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {

        string _login = "";
        string _password = "";

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

        private bool _hasLongActivity = false;

        public bool HasLongActivity
        {
            get { return _hasLongActivity; }
            set
            {
                SetProperty(ref _hasLongActivity, value);
            }
        }

        public DelegateCommand SignInCommand { get; set; }
        public DelegateCommand SignUpCommand { get; set; }

        public SignInViewModel(INavigationService navigationService, IUserService userService) :
            base(navigationService)
        {
            var c = System.Globalization.CultureInfo.CurrentUICulture;
            SignInCommand = new DelegateCommand(async () =>
           {
               HasLongActivity = true;
               var user = await userService.SignInAsync(Login, Password);
               HasLongActivity = false;
               if (user != null)
               {
                   await navigationService.NavigateAsync("MainListView");
               }
               else
                   UserDialogs.Instance.Alert(new AlertConfig()
                   {
                       Title = TextResources["Error"],
                       Message = TextResources["UserNotFound"],
                       OkText = TextResources["Ok"],
                       OnAction = () => Password = ""

                   });


           },
            () => Login.Length != 0 && Password.Length != 0 && !HasLongActivity
            );

            SignInCommand.ObservesProperty(() => Login);
            SignInCommand.ObservesProperty(() => Password);
            SignInCommand.ObservesProperty(() => HasLongActivity);

            SignUpCommand = new DelegateCommand(() => navigationService.NavigateAsync("SignUpView"));
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Login = parameters.GetValue<string>("Login") ?? Login;
            Password = parameters.GetValue<string>("Password") ?? Password;
        }
    }
}
