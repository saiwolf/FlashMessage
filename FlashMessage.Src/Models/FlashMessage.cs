namespace SWMNU.Net.FlashMessage
{
    /// <summary>
    /// Enumeration of valid Bootstrap alert theme colors.
    /// </summary>
    public enum AlertType
    {
        /// <summary>
        /// Creates an alert with the Bootstrap 'Primary' theme color.
        /// </summary>
        Primary,
        /// <summary>
        /// Creates an alert with the Bootstrap 'Secondary' theme color.
        /// </summary>
        Secondary,
        /// <summary>
        /// Creates an alert with the Bootstrap 'Success' theme color.
        /// </summary>
        Success,
        /// <summary>
        /// Creates an alert with the Bootstrap 'Danger' theme color.
        /// </summary>
        Danger,
        /// <summary>
        /// Creates an alert with the Bootstrap 'Warning' theme color.
        /// </summary>
        Warning,
        /// <summary>
        /// Creates an alert with the Bootstrap 'Info' theme color.
        /// </summary>
        Info,
        /// <summary>
        /// Creates an alert with the Bootstrap 'Light' theme color.
        /// </summary>
        Light,
        /// <summary>
        /// Creates an alert with the Bootstrap 'Dark' theme color.
        /// </summary>
        Dark
    }

    /// <summary>
    /// POCO Class for defining an flash message as a Bootstrap alert.
    /// </summary>
    public class AlertMessage
    {
        /// <summary>
        /// The meat of the message.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// An optional title. Will get a `&lt;h4&gt;` tag with the class `alert-heading`.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The type of Alert to display. Defined in <see cref="AlertType"/>.
        /// </summary>
        public AlertType Type { get; set; }
        /// <summary>
        /// <para>
        /// Boolean determining if the generated alert should be dismissible.
        /// </para>
        /// <para>
        /// True: An X appears in the upper right of the alert.
        /// </para>
        /// <para>
        /// False: No X appears.
        /// </para>
        /// </summary>
        public bool Dismissible { get; set; } = false;
    }
}