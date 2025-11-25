var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();

app.MapGet("/", () => "Currency API is running");

app.Run();
