using PortfolioRestAPI.DAL;
using PortfolioRestAPI.Services;

namespace PortfolioRestAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Registering the services EmailService
            // It specifies that whenever an instance of ISendService is requested
            // there should also be a an instance of EmailService
            builder.Services.AddScoped<ISendService, EmailService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<DALManager>(); // Dependency injection

            var app = builder.Build();
            app.UseCors(builder=>builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}