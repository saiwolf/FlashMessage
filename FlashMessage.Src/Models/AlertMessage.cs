namespace SWMNU.Net.FlashMessage
{
    /// <summary>
    /// Base Message Class.
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
        /// <summary>
        /// <para>Added to maintain backwards compatibility with Bootstrap 4.x</para>
        /// <para>Boolean controlling the use of Bootstrap classes between versions 4.x and 5.x</para>
        /// <para>True uses the old 4.x classes, False uses the new 5.x classes.</para>
        /// </summary>
        public bool UseBootstrap4 { get; set; } = false;
    }
}