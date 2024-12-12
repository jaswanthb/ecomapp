namespace CancellationTknDemo
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(ex, context);
            }
        }

        private async Task HandleException(Exception ex, HttpContext httpContext)
        {
            Console.WriteLine(ex.Message);
            if (ex is InvalidOperationException)
            {
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsJsonAsync(new
                {
                    Message = "Invalid operation",
                    StatusCode = 400,
                    Success = false
                });
            }
            else if (ex is TaskCanceledException)
            {
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = 499;
                //await httpContext.Response.WriteAsync("Task cancelled");
            }
            else if (ex is DivideByZeroException)
            {
                await httpContext.Response.WriteAsync("Cannot divide by zero");
            }
            else
            {
                //DB, File, External logs
                await httpContext.Response.WriteAsync("Unknown error");
            }
        }
    }
}
