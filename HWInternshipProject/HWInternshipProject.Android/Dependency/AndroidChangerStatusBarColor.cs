using HWInternshipProject.Dependency;
using Xamarin.Forms;
using Plugin.CurrentActivity;

[assembly: Dependency(typeof(HWInternshipProject.Droid.Dependency.AndroidChangerStatusBarColor))]
namespace HWInternshipProject.Droid.Dependency
{
    class AndroidChangerStatusBarColor : IChangerStatusBarColor
    {
        public void SetBarColor(Color color)
        {
            CrossCurrentActivity.Current?.Activity?.Window?.SetStatusBarColor(Android.Graphics.Color.ParseColor(color.ToHex()));
            CrossCurrentActivity.Current?.Activity?.Window?.SetNavigationBarColor(Android.Graphics.Color.ParseColor(color.ToHex()));
        }
    }
}