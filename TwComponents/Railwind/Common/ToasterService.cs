using Railwind.Common.Enums;

namespace Railwind.Common;

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

        // Start a timer to remove the toast after the duration
        // Task.Delay(duration, cts.Token).ContinueWith(_ => RemoveToast(toast.Id));
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

        // toasts.Add(toast);
        OnToastCreate?.Invoke(toast);

        // Start a timer to remove the toast after the duration
        // Task.Delay(duration, cts.Token).ContinueWith(task => RemoveToast(toast.Id), TaskScheduler.Default);
    }

}