using System;
using System.Collections.Generic;
using System.Resources;

using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;

using Prism;
using Prism.Commands;
using Prism.Navigation;
using Prism.Ioc;

using HWInternshipProject.Views;
using HWInternshipProject.ViewModels;
using HWInternshipProject.Services.Models;
using HWInternshipProject.Services.Settings;
using HWInternshipProject.Services.Validators;
using HWInternshipProject.Dependency;
using Xamarin.Forms.Xaml;
using HWInternshipProject.Models;

namespace HWInternshipProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
            Device.SetFlags(new string[] { "RadioButton_Experimental" });
        }

        protected override async void OnInitialized()
        {

            InitializeComponent();

            if (!this.Properties.ContainsKey("login"))
                this.Properties.Add("login", "malexit240");
            if (!this.Properties.ContainsKey("password"))
                this.Properties.Add("password", "Password123");

            var login = this.Properties["login"];
            var password = this.Properties["password"];

            new SettingsManager().CurrentCultureInfo = new SettingsManager().CurrentCultureInfo;
            new SettingsManager().Theme = new SettingsManager().Theme;

            using (var context = new Context()) { }

            await NavigationService.NavigateAsync("NavigationPage/SignInView", ("Login", login), ("Password", password));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterInstance<ISettingsManager>(Container.Resolve<SettingsManager>());

            containerRegistry.RegisterInstance<ILoginValidatorService>(Container.Resolve<LoginValidatorService>((typeof(IUserManager), new UserManager())));
            containerRegistry.RegisterInstance<IPasswordValidatorService>(Container.Resolve<PasswordValidatorService>());

            containerRegistry.RegisterInstance<IUserManager>(Container.Resolve<UserManager>());
            containerRegistry.RegisterInstance<IUserService>(Container.Resolve<UserService>());

            containerRegistry.RegisterInstance<IProfileManager>(Container.Resolve<ProfileManager>());
            containerRegistry.RegisterInstance<IProfileService>(Container.Resolve<ProfileService>((typeof(IProfileManager), new ProfileManager())));

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SignInView, SignInViewModel>();
            containerRegistry.RegisterForNavigation<MainListView, MainListViewModel>();
            containerRegistry.RegisterForNavigation<SignUpView, SignUpViewModel>();
            containerRegistry.RegisterForNavigation<AddEditProfileView, AddEditProfileViewModel>();
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
            containerRegistry.RegisterForNavigation<SizedProfileImagePage, SizedProfileImagePageViewModel>();
        }
    }
}