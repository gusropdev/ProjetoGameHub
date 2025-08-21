using System.Text.Json.Serialization;
using GameHub.Domain.Enums;

namespace GameHub.Application.Common.Responses;

public class Result<T>
{
    [JsonIgnore]
    public bool IsSuccess { get; }
    public T? Data { get; }
    public List<string> Errors { get; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ErrorType ErrorType { get; }

    protected Result(bool isSuccess, T? data, List<string> errors, ErrorType errorType)
    {
        IsSuccess = isSuccess;
        Data = data;
        Errors = errors ?? [];
        ErrorType = errorType;
    }
    public static Result<T> Success(T data)
    {
        return new Result<T>(true, data, [], ErrorType.None);
    }

    public static Result<T> Failure(List<string> errors, ErrorType errorType = ErrorType.Validation)
    {
        return new Result<T>(false, default, errors, errorType);
    }
    
    public static Result<T> Failure(string error, ErrorType errorType = ErrorType.Validation)
    {
        return new Result<T>(false, default, [error], errorType);
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