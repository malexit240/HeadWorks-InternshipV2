using System;
using Prism.Mvvm;
using HWInternshipProject.Models;
using System.Globalization;
using Prism.Commands;
using Prism.Common;
using Prism.Navigation;
using HWInternshipProject.Services.Models;
using HWInternshipProject.Resources;
using Acr.UserDialogs;
using HWInternshipProject.Views;
using Xamarin.Forms;

namespace HWInternshipProject.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        Profile _profile;

        public string Name
        {
            get { return _profile.Name; }
            set
            {
                _profile.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string NickName
        {
            get { return _profile.NickName; }
            set
            {
                _profile.NickName = value;
                RaisePropertyChanged("NickName");
            }
        }

        public string Date
        {
            get
            {
                return _profile.CreationTime.Date.ToString(CultureInfo.CurrentUICulture.DateTimeFormat.LongDatePattern);
            }
        }

        public string ImageDestination
        {
            get
            {
                return _profile.ImageDestination == "" ? "DefaultProfilePicture.png" : _profile.ImageDestination;
            }
        }

        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand EditCommand { get; set; }

        public DelegateCommand OpenProfileImageCommand { get; set; }

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
    }
}
