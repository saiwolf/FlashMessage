namespace SWMNU.Net.FlashMessage;

/// <summary>
/// Base Message Class.
/// </summary>
public class AlertMessage
{
    private string? _text;
    private string? _title;
    private AlertType _type;
    private bool _dismissible;
    private bool _useBootstrap4;

    /// <summary>
    /// AlertMessage constructor
    /// </summary>
    /// <param name="alertText">Text of alert</param>
    /// <param name="alertTitle">(Optional) Title of alert</param>
    /// <param name="alertType">Type/Color of Alert</param>
    /// <param name="isDismissible">Controls if Alert is dismissible</param>
    /// <param name="useBS4">Controls legacy BS 4.x behavior</param>
    public AlertMessage(
        string? alertText,
        string? alertTitle,
        AlertType alertType,
        bool isDismissible = false,
        bool useBS4 = false)
    {
        _text = alertText;
        _title = alertTitle;
        _type = alertType;
        _dismissible = isDismissible;
        _useBootstrap4 = useBS4;
    }

    /// <summary>
    /// Parameter-less constructor.
    /// </summary>
    public AlertMessage() { }

    /// <summary>
    /// The meat of the message.
    /// </summary>
    public string? Text 
    {
        get => _text;
        set => _text = value;
    }
    /// <summary>
    /// An optional title. Will get a `&lt;h4&gt;` tag with the class `alert-heading`.
    /// </summary>
    public string? Title
    {
        get => _title;
        set => _title = value;
    }
    /// <summary>
    /// The type of Alert to display. Defined in <see cref="AlertType"/>.
    /// </summary>
    public AlertType Type
    {
        get => _type;
        set => _type = value;
    }
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
    public bool Dismissible
    {
        get => _dismissible;
        set => _dismissible = value;
    }
    /// <summary>
    /// <para>Added to maintain backwards compatibility with Bootstrap 4.x</para>
    /// <para>Boolean controlling the use of Bootstrap classes between versions 4.x and 5.x</para>
    /// <para>True uses the old 4.x classes, False uses the new 5.x classes.</para>
    /// </summary>
    public bool UseBootstrap4
    {
        get => _useBootstrap4;
        set => _useBootstrap4 = value;
    }
}