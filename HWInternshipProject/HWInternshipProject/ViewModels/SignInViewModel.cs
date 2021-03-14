using Prism.Commands;
using Prism.Navigation;
using Acr.UserDialogs;
using HWInternshipProject.Services.Models;
using HWInternshipProject.Views;

namespace HWInternshipProject.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        #region ---Bindable Properties---
        private string _login = "";
        private string _password = "";
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

        public bool HasLongActivity
        {
            get => _hasLongActivity;
            set => SetProperty(ref _hasLongActivity, value);
        }
        #endregion

        #region ---Commands---
        public DelegateCommand SignInCommand { get; set; }
        public DelegateCommand SignUpCommand { get; set; }
        #endregion

        #region ---Constructors---
        public SignInViewModel(INavigationService navigationService, IUserService userService) :
            base(navigationService)
        {
            SignInCommand = new DelegateCommand(async () =>
           {
               HasLongActivity = true;
               var user = await userService.SignInAsync(Login, Password);
               HasLongActivity = false;

               if (user != null)
                   await navigationService.NavigateAsync(nameof(MainListView));
               else
                   UserDialogs.Instance.Alert(new AlertConfig()
                   {
                       Title = TextResources["Error"],
                       Message = TextResources["UserNotFound"],
                       OkText = TextResources["Ok"],
                       OnAction = () => Password = ""
                   });
           }, () => Login.Length != 0 && Password.Length != 0 && !HasLongActivity);

            SignInCommand.ObservesProperty(() => Login);
            SignInCommand.ObservesProperty(() => Password);
            SignInCommand.ObservesProperty(() => HasLongActivity);

            SignUpCommand = new DelegateCommand(() => navigationService.NavigateAsync("SignUpView"));
        }
        #endregion

        #region ---Overrides---
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Login = parameters.GetValue<string>("Login") ?? Login;
            Password = parameters.GetValue<string>("Password") ?? Password;

        }
        #endregion
    }
}
