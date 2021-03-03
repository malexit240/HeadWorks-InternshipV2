using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using HWInternshipProject.Services;
using System.Threading.Tasks;
using HWInternshipProject.Resources;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace HWInternshipProject.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible, IInitializeAsync
    {
        protected INavigationService NavigationService { get; private set; }

        public LocalizedResources TextResources { get; private set; }


        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
            TextResources = new LocalizedResources(typeof(HWInternshipProject.Resources.TextResources), System.Globalization.CultureInfo.CurrentUICulture);
        }


        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        public virtual async Task InitializeAsync(INavigationParameters parameters)
        {

        }
    }
}
