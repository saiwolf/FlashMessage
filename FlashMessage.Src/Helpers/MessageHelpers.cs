using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWMNU.Net.FlashMessage
{
    /// <summary>
    /// Utility class for various Message display helper functions.
    /// </summary>
    public static class MessageHelpers
    {
        /// <summary>
        /// <para>Builds an HTML errors list from a c# List of ModelState errors.</para>
        /// </summary>
        /// <param name="modelStateErrors">A string-type List of errors from the ModelState</param>
        /// <returns>String of HTML for displaying errors or an Empty string if something went wrong.</returns>
        public static string BuildFormErrorString(List<string> modelStateErrors)
        {
            if (modelStateErrors.Count() == 0)
                return string.Empty;

            var sbString = new StringBuilder();

            sbString.Append("<ul>");

            foreach (var error in modelStateErrors)
            {
                sbString.Append($"<li>{error}</li>");
            }

            sbString.Append("</ul>");

            var htmlString = sbString.ToString();

            if (htmlString.Contains("<li>"))
            {
                return htmlString;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
