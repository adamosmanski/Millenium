
using Millenium.Application.Handlers;
using Millenium.Application.Interfaces;
using Millenium.Application.Queries;
using Millenium.Application.Services;
using Millenium.Data.Interfaces;
using Millenium.Data.Services;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Millenium.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICardRepository, CardRepository>();
            builder.Services.AddScoped<IActionService, ActionService>();
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetAllowedActionsHandler).Assembly);
            });


            builder.Services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazor",
                    policy =>
                    {
                        policy.WithOrigins(
                            "https://localhost:7059",  // Blazor dev server
                            "http://localhost:5073",   // Blazor dev server (HTTP)
                            "https://localhost:7219",   // API itself
                            "http://localhost:5185")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowBlazor");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
