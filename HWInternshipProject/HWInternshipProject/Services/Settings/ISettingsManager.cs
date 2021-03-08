using System.Globalization;

namespace HWInternshipProject.Services.Settings
{
    /// <summary>
    /// Defines the interface for saving and applying settings
    /// </summary>
    public interface ISettingsManager
    {
        /// <summary>
        /// Current theme in application
        /// </summary>
        Theme Theme { get; set; }

        /// <summary>
        /// Current order of profiles list in mainlist view
        /// </summary>
        ProfilesListOrderBy ProfilesListOrderBy { get; set; }

        /// <summary>
        /// Current CultureInfo in application
        /// </summary>
        CultureInfo CurrentCultureInfo { get; set; }

        /// <summary>
        /// Initializes settings manager
        /// </summary>
        void Init();
    }
}
