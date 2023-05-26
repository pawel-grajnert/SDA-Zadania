using BookRecord.Domain.Interfaces.Logic;
using BookRecord.Domain.Interfaces.Repository;
using BookRecord.Repository.Context;
using BookRecord.Repository.Repositories;
using BookRecord.ServiceLogic.BookLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookRecord.WebApi
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

            //Application Services
            builder.Services.AddTransient<IBookRepository, BookRepository>();
            builder.Services.AddTransient<IBookService, BookService>();
            
            //DataBase Connection Setup
            builder.Services.AddDbContext<BookRecordContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookRecord")));

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