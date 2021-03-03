using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Text;
using Xamarin.Forms;

namespace HWInternshipProject.Resources
{
    public class LocalizedResources : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        const string DEFAULT_LANGUAGE = "en-US";

        readonly ResourceManager ResourceManager;
        CultureInfo CurrentCultureInfo;

        public string this[string key]
        {
            get
            {
                return ResourceManager.GetString(key, CurrentCultureInfo);
            }
        }

        public LocalizedResources(Type resource, string language = null)
        : this(resource, new CultureInfo(language ?? DEFAULT_LANGUAGE))
        { }

        public LocalizedResources(Type resource, CultureInfo cultureInfo)
        {
            CurrentCultureInfo = cultureInfo;
            ResourceManager = new ResourceManager(resource);

            MessagingCenter.Subscribe<object, CultureChangedMessage>(this,
                string.Empty, OnCultureChanged);
        }

        private void OnCultureChanged(object s, CultureChangedMessage ccm)
        {
            CurrentCultureInfo = ccm.NewCultureInfo;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item"));
        }
    }
}
