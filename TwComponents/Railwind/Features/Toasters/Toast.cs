using Railwind.Common.Enums;

namespace Railwind.Features.Toasters;

public partial class Toast
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public string Title { get; set; }
    public int Duration { get; set; }
    public bool DoesExpire { get; set; } = true;
    public DateTime UtcExpirationTime { get; set; }
    public ToastSeverity Severity { get; set; } = ToastSeverity.Success;
    public CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();

}