using WebAppAda.Midleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<AuthMiddleware>();

app.MapGet("/", () => "Hello World!");

app.Run();
