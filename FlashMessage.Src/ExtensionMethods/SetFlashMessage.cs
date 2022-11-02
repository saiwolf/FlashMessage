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
            tempData[$"{tempKeyName}.UseBootstrap4"] = alertMessage.UseBootstrap4 ? "true" : "false";
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
        /// Sets Flash Message params in TempData.
        /// </summary>
        /// <param name="tempData">Current TempData object for Controller or Page.</param>
        /// <param name="text">Alert text</param>
        /// <param name="title">Optional alert title</param>
        /// <param name="alertType">Type/Color of Alert</param>
        /// <param name="dismissible">Controls if alert is dismissible</param>
        /// <param name="useBootstrap4">Controsl legacy Boostrap 4.x use</param>
        public static void SetFlashMessage(
            this ITempDataDictionary tempData,
            string text,
            string? title,
            AlertType alertType,
            bool dismissible = false,
            bool useBootstrap4 = false)
        {
            AlertMessage alertMessage = new(text, title, alertType, dismissible, useBootstrap4);
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

        #region Convience Methods
        /// <summary>
        /// Renders a green 'success' message
        /// </summary>
        /// <param name="tempData">Current TempData object for Controller or Page.</param>
        /// <param name="text">Alert text</param>
        /// <param name="title">Optional alert title</param>
        /// <param name="dismissible">Controls if alert is dismissible</param>
        /// <param name="useBootstrap4">Controsl legacy Boostrap 4.x use</param>
        public static void SetSuccessMessage(
            this ITempDataDictionary tempData,
            string text,
            string? title,
            bool dismissible = true,
            bool useBootstrap4 = false) 
        => SetFlashMessage(tempData, text, title, AlertType.Success, dismissible, useBootstrap4);


        /// <summary>
        /// Renders a red 'Danger' or 'Error' message
        /// </summary>
        /// <param name="tempData">Current TempData object for Controller or Page.</param>
        /// <param name="text">Alert text</param>
        /// <param name="title">Optional alert title</param>
        /// <param name="dismissible">Controls if alert is dismissible</param>
        /// <param name="useBootstrap4">Controsl legacy Boostrap 4.x use</param>
        public static void SetErrorMessage(
            this ITempDataDictionary tempData,
            string text,
            string? title,
            bool dismissible = false,
            bool useBootstrap4 = false)
        => SetFlashMessage(tempData, text, title, AlertType.Danger, dismissible, useBootstrap4);

        /// <summary>
        /// Renders an yellow/orange 'Warning' message
        /// </summary>
        /// <param name="tempData">Current TempData object for Controller or Page.</param>
        /// <param name="text">Alert text</param>
        /// <param name="title">Optional alert title</param>
        /// <param name="dismissible">Controls if alert is dismissible</param>
        /// <param name="useBootstrap4">Controsl legacy Boostrap 4.x use</param>
        public static void SetWarningMessage(
            this ITempDataDictionary tempData,
            string text,
            string? title,
            bool dismissible = true,
            bool useBootstrap4 = false)
        => SetFlashMessage(tempData, text, title, AlertType.Warning, dismissible, useBootstrap4);

        /// <summary>
        /// Renders a light-blue Informational message
        /// </summary>
        /// <param name="tempData">Current TempData object for Controller or Page.</param>
        /// <param name="text">Alert text</param>
        /// <param name="title">Optional alert title</param>
        /// <param name="dismissible">Controls if alert is dismissible</param>
        /// <param name="useBootstrap4">Controsl legacy Boostrap 4.x use</param>
        public static void SetInfoMessage(
            this ITempDataDictionary tempData,
            string text,
            string? title,
            bool dismissible = true,
            bool useBootstrap4 = false)
        => SetFlashMessage(tempData, text, title, AlertType.Info, dismissible, useBootstrap4);
        #endregion
    }
}
