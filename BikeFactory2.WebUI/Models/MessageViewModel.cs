namespace BikeFactory2.WebUI.Models;

public enum EMessageType
{
    Primary,
    Secondary,
    Success,
    Info,
    Warning,
    Danger
}

public class MessageViewModel
{
    public EMessageType MessageType { get; set; }

    public string BootstrapType
    {
        get
        {
            return MessageType.ToString().ToLower();
        }
    }

    public string Message { get; set; } = string.Empty;


    public MessageViewModel(EMessageType messageType, string message)
    {
        MessageType = messageType;
        Message = message;
    }
}
