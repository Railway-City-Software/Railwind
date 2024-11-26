using Railwind.Common.Enums;
using Railwind.Common.Models;

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
    
    public void ShowOutcomeToast(Outcome outcome, int duration = 3000)
    {
        var title = outcome.Status switch
        {
            OutcomeStatus.Succeeded => "Success",
            OutcomeStatus.Unauthorized => "Unauthorized",
            OutcomeStatus.Canceled => "Cancelled",
            OutcomeStatus.Processing => "Processing",
            OutcomeStatus.Failed => "Error",
            _ => ""
        };
        
        var severity = outcome.Status switch
        {
            OutcomeStatus.Succeeded => ToastSeverity.Success,
            OutcomeStatus.Unauthorized => ToastSeverity.Warning,
            OutcomeStatus.Canceled => ToastSeverity.Info,
            OutcomeStatus.Processing => ToastSeverity.Info,
            OutcomeStatus.Failed => ToastSeverity.Error,
            _ => ToastSeverity.Info
        };

        var toast = new Toast
        {
            Id = Guid.NewGuid(),
            Message = outcome.Message,
            Title = title,
            Duration = duration,
            Severity = severity
        };

        OnToastCreate?.Invoke(toast);
    }

}