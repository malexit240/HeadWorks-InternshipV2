using System.Collections.Generic;
using Xamarin.Essentials;
using Prism.Commands;
using Prism.Navigation;
using Acr.UserDialogs;
using HWInternshipProject.Models;
using HWInternshipProject.Services.Models;

namespace HWInternshipProject.ViewModels
{
    public class AddEditProfileViewModel : ViewModelBase
    {
        bool _IsEdit = false;
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

        public string Description
        {
            get => _profile.Description;
            set
            {
                _profile.Description = value;
                RaisePropertyChanged("Description");
            }
        }

        public string ImageDestination
        {
            get => _profile.ImageDestination == "" ? "DefaultProfilePicture.png" : _profile.ImageDestination;
            set
            {
                _profile.ImageDestination = value;
                RaisePropertyChanged("ImageDestination");
            }
        }

        public DelegateCommand AddSaveCommand { get; set; }
        public DelegateCommand SelectImageCommand { get; set; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("profile"))
            {
                _IsEdit = true;
                _profile = parameters.GetValue<Profile>("profile");
                RaisePropertyChanged("Name");
                RaisePropertyChanged("NickName");
                RaisePropertyChanged("Description");
                RaisePropertyChanged("ImageDestination");
            }
        }

        public AddEditProfileViewModel(INavigationService navigationService, IProfileService profileService) :
            base(navigationService)
        {
            _profile = new Profile() { UserId = User.Current.UserId };
            AddSaveCommand = new DelegateCommand(() =>
            {

                if (NickName == "" || Name == "")
                {
                    UserDialogs.Instance.Alert(TextResources["FiledsNandNNmustbefilled"], TextResources["Error"], TextResources["Ok"]);
                    return;
                }

                if (_IsEdit)
                    profileService.UpdateProfile(_profile);
                else
                    profileService.AddProfile(_profile);
                navigationService.GoBackAsync();
            });

            SelectImageCommand = new DelegateCommand(() =>
            {
                UserDialogs.Instance.ActionSheet(new ActionSheetConfig()
                {
                    Message = TextResources["ChooseAction"],
                    Options = new List<ActionSheetOption>()
                    {
                        new ActionSheetOption(TextResources["PickAtGallery"], async ()=>{
                            var result = await FilePicker.PickAsync();
                            ImageDestination = result?.FullPath ?? ImageDestination;
                        },"ic_collections_3x.png"),

                        new ActionSheetOption(TextResources["TakeAPhotoWithCamera"], async ()=>{
                            var result = await MediaPicker.CapturePhotoAsync();
                            ImageDestination = result?.FullPath ?? ImageDestination;
                        },"ic_camera_alt3x.png")
                    },
                    Cancel = new ActionSheetOption(TextResources["Cancel"])
                });
            });
        }
    }
}
