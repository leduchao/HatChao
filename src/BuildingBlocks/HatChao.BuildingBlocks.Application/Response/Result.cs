namespace HatChao.BuildingBlocks.Application.Response;

public class Result<TResponse>
{
    private readonly bool _isSuccess;

    public bool Succeeded => _isSuccess;

    public TResponse? Data { get; set; }

    public Error? Error { get; protected set; }

    private Result(TResponse? data)
    {
        _isSuccess = true;
        Data = data;
    }

    private Result(Error? error)
    {
        _isSuccess = false;
        Error = error;
    }

    public static Result<TResponse> Success(TResponse? data) => new(data);

    public static Result<TResponse> Failure(Error error) => new(error);
}

public class Result
{
    private readonly bool _isSuccess;

    public bool Succeeded => _isSuccess;

    public Error? Error { get; protected set; }

    private Result(bool isSuccess, Error? error)
    {
        _isSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, null);

    public static Result Failure(Error error) => new(false, error);
}
