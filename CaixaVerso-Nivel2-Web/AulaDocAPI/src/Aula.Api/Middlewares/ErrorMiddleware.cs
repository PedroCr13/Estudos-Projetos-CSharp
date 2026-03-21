namespace Aula.Api.Middlewares
{
    // Midleware criado para encapsular retorno em caso de exceção.
    // posibilita padroniza código
    // para usar adicionar na program: app.UseMiddleware<ErrorMiddleware>(); (antes das controllers)
    // regra: toda vez que gerar exceção rertornar badrequest com mensagem
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorMiddleware> _logger;

        // próximo mildleware é o MapControllers() (na program)
        public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                _logger.LogInformation("Starting...");
                await _next.Invoke(context);
                _logger.LogInformation("Finished with sucess");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    Message = ex.Message,
                });

                _logger.LogError(ex, "Finished with error");
            }
        }
    }
}
