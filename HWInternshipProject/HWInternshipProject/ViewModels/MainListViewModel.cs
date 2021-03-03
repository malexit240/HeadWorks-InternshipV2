using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using HWInternshipProject.Views;
using HWInternshipProject.Models;
using HWInternshipProject.Services.Models;
using HWInternshipProject.Services.Settings;

namespace HWInternshipProject.ViewModels
{
    public class MainListViewModel : ViewModelBase
    {
        User _user;
        ObservableCollection<ProfileViewModel> _profiles = new ObservableCollection<ProfileViewModel>();

        protected ISettingsManager SettingsManager { get; private set; }

        public DelegateCommand AddProfileCommand { get; set; }
        public DelegateCommand LogOutCommand { get; set; }
        public DelegateCommand GoToSettingsViewCommand { get; set; }


        public bool IsNoProfilesAdded { get => Profiles.Count == 0; }

        public bool IsListVisible { get => !IsNoProfilesAdded; }

        public ObservableCollection<ProfileViewModel> Profiles
        {
            get => _profiles;
            set => SetProperty(ref _profiles, value);
        }

        private void ReloadProfiles()
        {
            Profiles.Clear();

            switch (SettingsManager.ProfilesListOrderBy)
            {
                case ProfilesListOrderBy.Name:
                    _user.Profiles = _user.Profiles.OrderBy(p => p.Name).ToList();
                    break;
                case ProfilesListOrderBy.NickName:
                    _user.Profiles = _user.Profiles.OrderBy(p => p.NickName).ToList();
                    break;
                case ProfilesListOrderBy.CreationTime:
                    _user.Profiles = _user.Profiles.OrderBy(p => p.CreationTime).ToList();
                    break;
            }

            foreach (var profile in _user.Profiles)
                Profiles.Add(new ProfileViewModel(NavigationService, (IProfileService)(App.Current.Container.Resolve(typeof(IProfileService))), profile));

            RaisePropertyChanged(nameof(IsNoProfilesAdded));
            RaisePropertyChanged(nameof(IsListVisible));

        }

        public override Task InitializeAsync(INavigationParameters parameters)
        {
            return Task.Run(() =>
            {
                _user = User.Current;
                ReloadProfiles();
            });
        }

        public DelegateCommand<ProfileViewModel> OpenProfileImageCommand { get; set; }

        public MainListViewModel(INavigationService navigationService, ISettingsManager settingsManager, IUserService userService) :
            base(navigationService)
        {
            SettingsManager = settingsManager;

            OpenProfileImageCommand = new DelegateCommand<ProfileViewModel>(item => item.OpenProfileImageCommand.Execute());

            Profile.Actualize += async (sender, args) =>
            {
                await Task.Run(() =>
                {
                    _user = User.Current;
                    ReloadProfiles();
                });
            };


            AddProfileCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync(nameof(AddEditProfileView));
            });

            LogOutCommand = new DelegateCommand(() =>
            {
                userService.LogOut();
                navigationService.GoBackToRootAsync();
            });

            GoToSettingsViewCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync(nameof(SettingsView));
            });

        }
    }
}
