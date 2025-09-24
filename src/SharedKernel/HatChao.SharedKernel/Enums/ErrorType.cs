using System.Net;

namespace HatChao.SharedKernel.Enums;

public enum ErrorType
{
    None = 0,
    BadRequest = HttpStatusCode.BadRequest,
    Unauthorized = HttpStatusCode.Unauthorized,
    Forbidden = HttpStatusCode.Forbidden,
    InternalError = HttpStatusCode.InternalServerError,
}
