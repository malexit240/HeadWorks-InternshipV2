using System.Globalization;

namespace HWInternshipProject.Resources
{
    /// <summary>
    /// Message that sends in message center with info about changes culture
    /// </summary>
    public class CultureChangedMessage
    {
        /// <summary>
        /// New CultureInfo
        /// </summary>
        public CultureInfo NewCultureInfo { get; set; }

        public CultureChangedMessage(CultureInfo cultureInfo) => NewCultureInfo = cultureInfo;

    }
}