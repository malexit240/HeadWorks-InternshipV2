using System.Globalization;
using Prism.Commands;
using Prism.Navigation;
using HWInternshipProject.Services.Settings;

namespace HWInternshipProject.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        ISettingsManager _settingsManager;

        public bool OrderBy_NickName
        {
            get => _settingsManager.ProfilesListOrderBy == ProfilesListOrderBy.NickName;
        }

        public bool OrderBy_Name
        {
            get => _settingsManager.ProfilesListOrderBy == ProfilesListOrderBy.Name;
        }

        public bool OrderBy_CreationTime
        {
            get => _settingsManager.ProfilesListOrderBy == ProfilesListOrderBy.CreationTime;
        }

        public bool IsLightTheme
        {
            get => _settingsManager.Theme == Theme.Light;
            set => _settingsManager.Theme = value ? Theme.Light : Theme.Dark;
        }

        public bool IsEn_US
        {
            get => _settingsManager.CurrentCultureInfo.Name == "en-US";
        }

        public bool IsRu_RU
        {
            get => _settingsManager.CurrentCultureInfo.Name == "ru-RU";
        }

        public DelegateCommand CheckedNickNameCommand { get; set; }
        public DelegateCommand CheckedNameCommand { get; set; }
        public DelegateCommand CheckedCreationTimeCommand { get; set; }

        public DelegateCommand CheckedEnglishCommand { get; set; }
        public DelegateCommand CheckedRussianCommand { get; set; }

        public SettingsViewModel(INavigationService navigationService, ISettingsManager settingsManager) :
            base(navigationService)
        {
            _settingsManager = settingsManager;

            CheckedNickNameCommand = new DelegateCommand(() => { _settingsManager.ProfilesListOrderBy = ProfilesListOrderBy.NickName; });
            CheckedNameCommand = new DelegateCommand(() => { _settingsManager.ProfilesListOrderBy = ProfilesListOrderBy.Name; });
            CheckedCreationTimeCommand = new DelegateCommand(() => { _settingsManager.ProfilesListOrderBy = ProfilesListOrderBy.CreationTime; });

            CheckedEnglishCommand = new DelegateCommand(() => { _settingsManager.CurrentCultureInfo = new CultureInfo("en-US"); });
            CheckedRussianCommand = new DelegateCommand(() => { _settingsManager.CurrentCultureInfo = new CultureInfo("ru-RU"); });
        }
    }
}
