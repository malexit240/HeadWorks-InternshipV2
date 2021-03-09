using System.Globalization;
using Prism.Commands;
using Prism.Navigation;
using Acr.UserDialogs;
using HWInternshipProject.Views;
using HWInternshipProject.Models;
using HWInternshipProject.Services.Models;
using HWInternshipProject.Services.Settings;

namespace HWInternshipProject.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        #region ---Bindable Properties---
        Profile _profile;

        public string Name
        {
            get => _profile.Name;
            set
            {
                _profile.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string NickName
        {
            get => _profile.NickName;
            set
            {
                _profile.NickName = value;
                RaisePropertyChanged("NickName");
            }
        }

        public string Date
        {
            get => _profile.CreationTime.Date.ToString(((ISettingsManager)App.Current.Container.Resolve(typeof(ISettingsManager))).CurrentCultureInfo.DateTimeFormat.ShortDatePattern);
        }

        public string ImageDestination
        {
            get => _profile.ImageDestination == "" ? "DefaultProfilePicture.png" : _profile.ImageDestination;
        }
        #endregion

        #region ---Commands---
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand EditCommand { get; set; }
        public DelegateCommand OpenProfileImageCommand { get; set; }
        #endregion

        #region ---Constructors---
        public ProfileViewModel(INavigationService navigationService, IProfileService profileService, Profile profile) :
            base(navigationService)
        {
            this._profile = profile;
            DeleteCommand = new DelegateCommand(() =>
            {
                UserDialogs.Instance.Confirm(new ConfirmConfig()
                {
                    Message = TextResources["WouldYouWantToDelete"],
                    OkText = TextResources["Yes"],
                    CancelText = TextResources["No"],
                    OnAction = (confirm) =>
                    {
                        if (confirm)
                            profileService.RemoveProfile(_profile);
                    }
                });
            });

            EditCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync(nameof(AddEditProfileView), ("profile", this._profile));
            });

            OpenProfileImageCommand = new DelegateCommand(() =>
            {
                var parameters = new NavigationParameters();
                parameters.Add(nameof(ImageDestination), ImageDestination);
                navigationService.NavigateAsync($"{nameof(SizedProfileImagePage)}", parameters, true, false);
            });
        }
        #endregion
    }
}
