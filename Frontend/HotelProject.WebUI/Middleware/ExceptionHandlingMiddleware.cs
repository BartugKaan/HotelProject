using System.Net;

namespace HotelProject.WebUI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred while executing the request.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "text/html";

            var response = $@"
<!DOCTYPE html>
<html>
<head>
    <title>Error - Hotel Management System</title>
    <meta charset='utf-8'>
    <style>
        body {{ font-family: Arial, sans-serif; margin: 0; padding: 40px; background-color: #f5f5f5; }}
        .error-container {{ max-width: 600px; margin: 0 auto; background: white; padding: 40px; border-radius: 8px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); }}
        .error-icon {{ color: #dc3545; font-size: 48px; text-align: center; margin-bottom: 20px; }}
        h1 {{ color: #dc3545; text-align: center; margin-bottom: 20px; }}
        .error-message {{ background: #f8f9fa; padding: 20px; border-radius: 4px; margin: 20px 0; }}
        .back-button {{ text-align: center; margin-top: 30px; }}
        .btn {{ display: inline-block; padding: 10px 20px; background: #007bff; color: white; text-decoration: none; border-radius: 4px; }}
        .btn:hover {{ background: #0056b3; }}
    </style>
</head>
<body>
    <div class='error-container'>
        <div class='error-icon'>⚠️</div>
        <h1>Oops! Something went wrong</h1>
        <div class='error-message'>
            <p>We're sorry, but an unexpected error has occurred. Our team has been notified and is working to fix the issue.</p>
            <p><strong>Error ID:</strong> {Guid.NewGuid()}</p>
            <p><strong>Time:</strong> {DateTime.Now:yyyy-MM-dd HH:mm:ss}</p>
        </div>
        <div class='back-button'>
            <a href='javascript:history.back()' class='btn'>Go Back</a>
            <a href='/Staff/Index' class='btn' style='margin-left: 10px;'>Admin Dashboard</a>
        </div>
    </div>
</body>
</html>";

            await context.Response.WriteAsync(response);
        }
    }
}