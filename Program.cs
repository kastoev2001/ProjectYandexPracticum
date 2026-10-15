using ProjectYandexPracticum.Date;
using ProjectYandexPracticum.Interfaces;
using ProjectYandexPracticum.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();