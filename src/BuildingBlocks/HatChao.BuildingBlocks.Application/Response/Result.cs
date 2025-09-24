using System.Net;

namespace HatChao.BuildingBlocks.Application.Response;

public class Result<TResponse>
{
    public bool Succeeded { get; }

    public TResponse? Data { get; set; }

    public ErrorType ErrorType { get; set; }

    public Error? Error { get; protected set; }

    private Result(TResponse? data)
    {
        Succeeded = true;
        ErrorType = ErrorType.None;
        Data = data;
    }

    private Result(ErrorType errorType, Error? error)
    {
        Succeeded = false;
        ErrorType = errorType;
        Error = error;
    }

    public static Result<TResponse> Success(TResponse? data) => new(data);

    public static Result<TResponse> Failure(Error error, ErrorType errorType = ErrorType.InternalError) => new(errorType, error);
}

public class Result
{
    public bool Succeeded { get; }

    public ErrorType ErrorType { get; set; }

    public Error? Error { get; protected set; }

    private Result(bool isSuccess, ErrorType errorType, Error? error)
    {
        if ((isSuccess && errorType != ErrorType.None) || (isSuccess && error is not null))
        {
            throw new ArgumentException("Success result must have no error");
        }

        Succeeded = isSuccess;
        ErrorType = errorType;
        Error = error;
    }

    public static Result Success() => new(true, ErrorType.None, null);

    public static Result Failure(Error error, ErrorType errorType = ErrorType.InternalError)
        => new(false, errorType, error);
}

public enum ErrorType
{
    None = 0,
    BadRequest = HttpStatusCode.BadRequest,
    Unauthorized = HttpStatusCode.Unauthorized,
    Forbidden = HttpStatusCode.Forbidden,
    NotFound = HttpStatusCode.NotFound,
    InternalError = HttpStatusCode.InternalServerError,
}
