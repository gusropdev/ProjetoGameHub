using GameHub.Domain.Enums;

namespace GameHub.Application.Common.Responses;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public List<string> Errors { get; }
    public ErrorType ErrorType { get; set; }

    private Result(bool isSuccess, T? value, List<string> errors, ErrorType errorType)
    {
        IsSuccess = isSuccess;
        Value = value;
        Errors = errors ?? [];
        ErrorType = errorType;
    }
    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value, [], ErrorType.None);
    }

    public static Result<T> Failure(List<string> errors, ErrorType errorType = ErrorType.Validation)
    {
        return new Result<T>(false, default, errors, errorType);
    }
}

public class Result
{
    public bool IsSuccess { get; }
    public List<string> Errors { get; }
    public ErrorType ErrorType { get; set; }

    private Result(bool isSuccess, List<string> errors, ErrorType errorType)
    {
        IsSuccess = isSuccess;
        Errors = errors ?? [];
        ErrorType = errorType;
    }

    public static Result Success()
    {
        return new Result(true, [], ErrorType.None);
    }

    public static Result Failure(List<string> errors, ErrorType errorType = ErrorType.Validation)
    {
        return new Result(false, errors, errorType);
    }
    
    public static Result Failure(string error, ErrorType errorType = ErrorType.Validation)
    {
        return new Result(false, [error], errorType);
    }
}