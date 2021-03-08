using Xamarin.Forms;

namespace HWInternshipProject.Dependency
{
    /// <summary>
    /// Defines interface that allows change status bar color
    /// </summary>
    public interface IChangerStatusBarColor
    {
        /// <summary>
        /// Change color of status bar
        /// </summary>
        /// <param name="color">new color</param>
        void SetBarColor(Color color);
    }
}
