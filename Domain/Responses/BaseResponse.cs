using Domain.Enums;

namespace Domain.Responses
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string? Message { get; set; }

        public StatusCode StatusCode { get; set; }

        public T? Data { get; set; }

    }

    public interface IBaseResponse<T>
    {
        string? Message { get; }
        StatusCode StatusCode { get; }

        T? Data { get; set; }
    }
}

