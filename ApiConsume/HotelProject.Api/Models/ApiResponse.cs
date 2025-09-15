using System.Net;

namespace HotelProject.Api.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public static ApiResponse<T> SuccessResult(T data, string message = "Operation successful")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = HttpStatusCode.OK
            };
        }

        public static ApiResponse<T> SuccessResult(string message = "Operation successful")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                StatusCode = HttpStatusCode.OK
            };
        }

        public static ApiResponse<T> ErrorResult(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                StatusCode = statusCode
            };
        }

        public static ApiResponse<T> NotFoundResult(string message = "Resource not found")
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                StatusCode = HttpStatusCode.NotFound
            };
        }
    }
}