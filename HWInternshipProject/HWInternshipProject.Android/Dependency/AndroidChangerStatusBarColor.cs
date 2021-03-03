using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HWInternshipProject.Dependency;
using Xamarin.Forms;
using Plugin.CurrentActivity;

[assembly: Dependency(typeof(HWInternshipProject.Droid.Dependency.AndroidChangerStatusBarColor))]
namespace HWInternshipProject.Droid.Dependency
{
    class AndroidChangerStatusBarColor : IChangerStatusBarColor
    {
        public void SetStatusBarColor(Color color)
        {
            CrossCurrentActivity.Current?.Activity?.Window?.SetStatusBarColor(Android.Graphics.Color.ParseColor(color.ToHex()));
            CrossCurrentActivity.Current?.Activity?.Window?.SetNavigationBarColor(Android.Graphics.Color.ParseColor(color.ToHex()));
        }
    }
}