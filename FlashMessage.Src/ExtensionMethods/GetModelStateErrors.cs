using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWMNU.Net.FlashMessage
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// <para>Gets all errors from current ModelState</para>
        /// <para>Extends off <c>ModelStateDictionary</c></para>
        /// <para>Adapted from: https://medium.com/yasser-shaikh/how-to-read-all-errors-from-modelstate-in-asp-net-mvc-7ad54f22386b</para>
        /// </summary>
        /// <param name="modelState">ModelState to extract errors from.</param>
        /// <returns><see cref="List{T}"/> of errors, or a 0 count List if no errors present.</returns>
        public static List<string> GetModelStateErrors(this ModelStateDictionary modelState)
        {
            IEnumerable<string>? errors = from state in modelState.Values
                                         from error in state.Errors
                                         select error.ErrorMessage;

            List<string>? errorList = errors.ToList();

            if (errorList is not null && errorList.Count > 0)
                return errorList;
            else
                return new List<string>();
        }
    }
}
