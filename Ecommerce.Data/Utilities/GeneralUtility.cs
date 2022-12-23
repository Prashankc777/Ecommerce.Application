using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Utilities
{
    public static class GeneralUtility
    {
        public static DateTime GetCurrentNepaliDateTime()
        {
            return DateTime.UtcNow.AddMinutes(345);
        }
    }
}
