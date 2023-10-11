using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifiedAgencies.Helpers
{
    public class Services
    {
        public static DateTime GetHijriDate(string stringDate)
        {
            string dateFormat = "yyyy-MM-dd"; // Example: "2023-10-09"

            DateTime.TryParseExact(stringDate, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime returnedDateTime);

            return returnedDateTime;
        }
    }
}
