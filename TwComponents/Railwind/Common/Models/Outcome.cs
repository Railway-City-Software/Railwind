using Railwind.Common.Enums;

namespace Railwind.Common.Models;

public class Outcome
{
    public OutcomeStatus Status { get; set; }
    public string Message { get; set; } = string.Empty;
    
    public static Outcome Successful(string message = "") => new()
    {
        Message = message,
        Status = OutcomeStatus.Succeeded
    };

    public static Outcome Failure(string message = "") => new()
    {
        Message = message,
        Status = OutcomeStatus.Failed
    };
    
    public static Outcome FromGenericOutcome<T>(Outcome<T> outcome) => new()
    {
        Message = outcome.Message,
        Status = outcome.Status
    };
    
    public bool IsFailure => Status == OutcomeStatus.Failed;
    public bool IsSuccessful => Status == OutcomeStatus.Succeeded;
}


public class Outcome<T>
{
    public T Data { get; set; }
    public OutcomeStatus Status { get; set; }
    public string Message { get; set; } = string.Empty;

    public static Outcome<T> Successful(T data, string message = "") => new()
    {
        Data = data,
        Message = message,
        Status = OutcomeStatus.Succeeded
    };
    
    public static Outcome<T> Failure(string message = "") => new ()
    {
        Data = default,
        Message = message,
        Status = OutcomeStatus.Failed
    };
    
      
    public static Outcome<T> Invalid(string message = "") => new ()
    {
        Data = default,
        Message = message,
        Status = OutcomeStatus.Invalid
    };
    
    public static Outcome<T> Unauthorized(string message = "") => new ()
    {
        Data = default,
        Message = message,
        Status = OutcomeStatus.Unauthorized
    };
    
    public static Outcome<T> Failure(T data = default, string message = "") => new ()
    {
        Data = data,
        Message = message,
        Status = OutcomeStatus.Failed
    };
    
    public bool IsFailure => Status == OutcomeStatus.Failed;
    public bool IsSuccessful => Status == OutcomeStatus.Succeeded;
}