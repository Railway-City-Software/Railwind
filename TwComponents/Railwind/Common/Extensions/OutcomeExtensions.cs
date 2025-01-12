using Railwind.Common.Models;

namespace Railwind.Common.Extensions;

public static class OutcomeExtensions
{
    public static Outcome ToOutcome<T>(this Outcome<T> outcome) => new()
    {
        Message = outcome.Message,
        Status = outcome.Status
    };
}