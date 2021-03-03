using System.Globalization;

namespace HWInternshipProject.Resources
{
    public class CultureChangedMessage
    {
        public CultureInfo NewCultureInfo { get; set; }

        public CultureChangedMessage(CultureInfo cultureInfo)
        {
            NewCultureInfo = cultureInfo;
        }
    }
}