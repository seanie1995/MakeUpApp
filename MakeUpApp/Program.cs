
using MakeUpApp.Data;
using MakeUpApp.Data.Repos;
using MakeUpApp.Data.Repos.IRepos;
using MakeUpApp.Models;
using MakeUpApp.Services;
using MakeUpApp.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace MakeUpApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MakeupContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<MakeupContext>()
            .AddDefaultTokenProviders();

            // Add services to the container.

            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IProductTypeRepo, ProductTypeRepo>();
            builder.Services.AddScoped<IProductServices, ProductServices>();
            builder.Services.AddScoped<IProductTypeServices, ProductTypeServices>();
            

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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
