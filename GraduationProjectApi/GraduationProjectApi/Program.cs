
using GraduationProjectApi.Data;
using GraduationProjectApi.Models;
using GraduationProjectApi.Services;
using GraduationProjectApi.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Configuration
            var connecitnoString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(option =>
                option.UseSqlServer(connecitnoString));

            builder.Services.AddTransient<IPersonService, PersonService>();
            builder.Services.AddTransient<IHospitalsService, HospitalsService>();
            builder.Services.AddTransient<IPharmaciesService, PharmaciesService>();
            builder.Services.AddTransient<INotesService, NotesService>();
            builder.Services.AddTransient<ISimilarRepository<Blood>, BloodsRepository>();
            builder.Services.AddTransient<ISimilarRepository<Hotline>, HotlinesRepository>();
            builder.Services.AddTransient<ISimilarRepository<Job>, JobsRepostirory>();
            builder.Services.AddTransient<ISimilarRepository<Kind>, KindsRepository>();

            builder.Services.AddAutoMapper(typeof(Program));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}