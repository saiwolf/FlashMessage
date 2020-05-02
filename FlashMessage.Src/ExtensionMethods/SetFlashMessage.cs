using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SWMNU.Net.FlashMessage
{
    /// <summary>
    /// Extension Methods class for extending built-in methods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Sets Flash Message params in TempData.
        /// </summary>
        /// <param name="tempData">Current TempData object for Controller or Page.</param>
        /// <param name="alertMessage">Flash Message to set in <paramref name="tempData"/></param>
        public static void SetFlashMessage(this ITempDataDictionary tempData, AlertMessage alertMessage)
        {
            tempData["FlashMessage.Text"] = string.IsNullOrEmpty(alertMessage.Text) ? string.Empty : alertMessage.Text;
            tempData["FlashMessage.Title"] = string.IsNullOrEmpty(alertMessage.Title) ? string.Empty : alertMessage.Title;
            tempData["FlashMessage.Type"] = alertMessage.Type.ToString().ToLower();
            tempData["FlashMessage.Dismissible"] = alertMessage.Dismissible ? "true" : "false";
        }
    }      
}
