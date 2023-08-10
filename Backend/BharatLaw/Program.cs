
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;


namespace BharatLaw
{
    public class Program
    {
        //private static object services;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ResearchBookDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ResearchBookDbContext")));
            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("SwaggerPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
            }
            app.UseCors("SwaggerPolicy");
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ResearchBookDbContext>();
                context.Database.EnsureCreated();
                // DbInitializer.Initialize(context);
            }

            //CreateHostBuilder(args).Build().Run();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
 
    }
}