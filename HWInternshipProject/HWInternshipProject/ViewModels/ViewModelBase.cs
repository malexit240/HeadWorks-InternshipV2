using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using HWInternshipProject.Resources;
using HWInternshipProject.Services.Settings;

namespace HWInternshipProject.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible, IInitializeAsync
    {
        protected INavigationService NavigationService { get; private set; }
        public LocalizedResources TextResources { get; private set; }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
            TextResources = new LocalizedResources(typeof(HWInternshipProject.Resources.TextResources), ((ISettingsManager)App.Current.Container.Resolve(typeof(ISettingsManager))).CurrentCultureInfo);
        }

        public virtual void Initialize(INavigationParameters parameters) { }
        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }
        public virtual void OnNavigatedTo(INavigationParameters parameters) { }
        public virtual void Destroy() { }
        public virtual async Task InitializeAsync(INavigationParameters parameters) { }
    }
}
