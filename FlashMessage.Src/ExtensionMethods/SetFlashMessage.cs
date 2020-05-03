using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SWMNU.Net.FlashMessage
{
    /// <summary>
    /// Extension Methods class for extending built-in methods.
    /// </summary>
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Sets Alert Message params in TempData.
        /// </summary>
        /// <param name="tempData">Current TempData object for Controller or Page.</param>
        /// <param name="alertMessage">Flash Message to set in <paramref name="tempData"/></param>
        /// <param name="tempKeyName"></param>
        public static void SetMessage(this ITempDataDictionary tempData, AlertMessage alertMessage, string tempKeyName = "FlashMessage")
        {
            if (string.IsNullOrEmpty(tempKeyName) || string.IsNullOrWhiteSpace(tempKeyName))
                tempKeyName = "FlashMessage";

            tempData[$"{tempKeyName}.Text"] = string.IsNullOrEmpty(alertMessage.Text) ? string.Empty : alertMessage.Text;
            tempData[$"{tempKeyName}.Title"] = string.IsNullOrEmpty(alertMessage.Title) ? string.Empty : alertMessage.Title;
            tempData[$"{tempKeyName}.Type"] = alertMessage.Type.ToString().ToLower();
            tempData[$"{tempKeyName}.Dismissible"] = alertMessage.Dismissible ? "true" : "false";
        }

        /// <summary>
        /// Sets Flash Message params in TempData.
        /// </summary>
        /// <param name="tempData">Current TempData object for Controller or Page.</param>
        /// <param name="alertMessage">Flash Message to set in <paramref name="tempData"/></param>
        public static void SetFlashMessage(this ITempDataDictionary tempData, AlertMessage alertMessage)
        {
            SetMessage(tempData, alertMessage, "FlashMessage");
        }

        /// <summary>
        /// Sets Form Message params in TempData.
        /// </summary>
        /// <param name="tempData">Current TempData object for Controller or Page.</param>
        /// <param name="formAlert">Flash Message to set in <paramref name="tempData"/></param>        
        public static void SetFormMessage(this ITempDataDictionary tempData, FormAlert formAlert)
        {
            SetMessage(tempData, formAlert, "FormMessage");

            tempData["FormMessage.Errors"] = string.IsNullOrEmpty(formAlert.Errors) ? string.Empty : formAlert.Errors;
        }
    }      
}
