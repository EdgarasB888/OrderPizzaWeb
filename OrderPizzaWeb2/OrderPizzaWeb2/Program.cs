using Microsoft.EntityFrameworkCore;
using OrderPizzaWeb2.Data;
using OrderPizzaWeb2.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddDbContext<OrderPizzaWebDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DatabaseConnectionString");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddTransient<IPizzaOrdersRepository, PizzaOrdersRepository>();
builder.Services.AddTransient<IToppingsRepository, ToppingsRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors();
app.UseRouting();
app.MapControllers();

app.Run();