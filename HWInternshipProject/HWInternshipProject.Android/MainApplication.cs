using System;
using Android.App;
using Android.Runtime;
using HWInternshipProject.Services.Settings;

namespace HWInternshipProject.Droid
{
    [Application(
        Theme = "@style/MainTheme"
        )]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();
            var settingsManager = new SettingsManager();
            settingsManager.CurrentCultureInfo = settingsManager.CurrentCultureInfo;

            Xamarin.Essentials.Platform.Init(this);

        }
    }
}
