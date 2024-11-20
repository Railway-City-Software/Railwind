using Railwind.Common.Enums;

namespace Railwind.Features.Toasters;

public class ToasterService
{
    public event Action<Toast> OnToastCreate;

    public void ShowToast(string message, string title = "", ToastSeverity severity = ToastSeverity.Info, int duration = 3000)
    {

        var toast = new Toast
        {
            Id = Guid.NewGuid(),
            Message = message,
            Title = title,
            Duration = duration,
            Severity = severity
        };

        OnToastCreate?.Invoke(toast);
    }
    
    public void ShowTitleToast(string title = "", ToastSeverity severity = ToastSeverity.Info, int duration = 3000)
    {

        var toast = new Toast
        {
            Id = Guid.NewGuid(),
            Message = "",
            Title = title,
            Duration = duration,
            Severity = severity
        };

        OnToastCreate?.Invoke(toast);
    }

}