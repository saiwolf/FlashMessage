namespace SWMNU.Net.FlashMessage;

/// <summary>
/// POCO Class for generating alerts for forms.
/// </summary>
public class FormAlert : AlertMessage
{
    /// <summary>
    /// String of Errors.
    /// </summary>
    public string? Errors { get; set; }
}
