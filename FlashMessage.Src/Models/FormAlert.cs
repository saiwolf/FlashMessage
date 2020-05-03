using Microsoft.AspNetCore.Html;
namespace SWMNU.Net.FlashMessage
{
    /// <summary>
    /// POCO Class for generating alerts for forms.
    /// </summary>
    public class FormAlert : AlertMessage
    {
        /// <summary>
        /// string of Errors.
        /// </summary>
        public string Errors { get; set; }
    }
}
