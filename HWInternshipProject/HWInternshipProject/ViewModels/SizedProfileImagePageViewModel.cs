using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.ComponentModel;

namespace HWInternshipProject.ViewModels
{
    public class SizedProfileImagePageViewModel : ViewModelBase
    {
        string _imageDestination;

        public string ImageDestination
        {
            get => _imageDestination;
            set => SetProperty(ref _imageDestination, value);
        }

        public DelegateCommand GoBackCommand { get; set; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("ImageDestination"))
                ImageDestination = parameters["ImageDestination"].ToString();

        }

        public SizedProfileImagePageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            GoBackCommand = new DelegateCommand(() =>
            {
                NavigationService.GoBackAsync();
            });
        }
    }
}
