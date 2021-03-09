using Prism.Commands;
using Prism.Navigation;

namespace HWInternshipProject.ViewModels
{
    public class SizedProfileImagePageViewModel : ViewModelBase
    {
        #region ---Bindable Properties---
        string _imageDestination = "";

        public string ImageDestination
        {
            get => _imageDestination;
            set => SetProperty(ref _imageDestination, value);
        }
        #endregion

        #region ---Commands---
        public DelegateCommand GoBackCommand { get; set; }
        #endregion

        #region ---Constructors---
        public SizedProfileImagePageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            GoBackCommand = new DelegateCommand(() =>
            {
                NavigationService.GoBackAsync(null, true, false);
            });
        }
        #endregion

        #region ---Overrides---
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("ImageDestination"))
                ImageDestination = parameters["ImageDestination"].ToString();
        }
        #endregion
    }
}
