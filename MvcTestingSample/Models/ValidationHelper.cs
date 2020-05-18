using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MvcTestingSample.Models
{
    public static class ValidationHelper
    {
        public static bool IsValidPrice(string price)
        {
            if (price == string.Empty)
            {
                return false;
            }

            // ^\$?\d{0,}\.?(\d{1,})?$
            // ^(\$)?([1-9]{1}[0-9]{0,2})(\,\d{3})*(\.\d{2})?$|^(\$)?([1-9]{1}[0-9]{0,2})(\d{3})*(\.\d{2})?$|^(0)?(\.\d{2})?$|^(\$0)?(\.\d{2})?$|^(\$\.)(\d{2})?$
            Regex pattern = new Regex(@"^\$?\d{0,}\.?(\d{1,})?$");
            return pattern.IsMatch(price);

            //try
            //{
            //    Convert.ToDouble(price);
            //    return true;
            //}
            //catch (FormatException)
            //{
            //    return false;
            //}
        }
    }
}
