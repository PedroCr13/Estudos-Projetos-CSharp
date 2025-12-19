namespace WebAppAda.Midleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            if (context.Request.Query.TryGetValue("codigo", out var seuCodigo)) 
            { 
                if (seuCodigo == "123")
                {
                    await _next(context);
                    return;
                }

                context.Response.StatusCode = 200;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Você não está autorizado...");
            }
        }
    }
}
