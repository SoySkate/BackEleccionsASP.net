
using BackEleccionsM.Interfaces;
using BackEleccionsM.Repository;
using BackEleccionsM.Services;
using BackEndEleccions.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEleccionsM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //esto es como importar dentro de la app el automapper y que pueda accedes a mapperar los assemblies
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            builder.Services.AddScoped<ICandidatRepository, CandidatRepository>();
            builder.Services.AddScoped<IMunicipiRepository, MunicipiRepository>();
            builder.Services.AddScoped<IPartitPoliticRepository, PartitPoliticRepository>();
            builder.Services.AddScoped<IResultatsTaulaRepository, ResultatsTaulaRepository>();
            builder.Services.AddScoped<ITaulaElectoralRepository, TaulaElectoralRepository>();
            builder.Services.AddScoped<IVotsPerPartitRepository, VotsPerPartitRepository>();

            builder.Services.AddScoped<ICandidatService, CandidatService>();
            builder.Services.AddScoped<IMunicipiService, MunicipiService>();
            builder.Services.AddScoped<IPartitPoliticService, PartitPoliticService>();
            builder.Services.AddScoped<IResultatsTaulaService, ResultatsTaulaService>();
            builder.Services.AddScoped<ITaulaElectoralService, TaulaElectoralService>();
            builder.Services.AddScoped<IVotsPerPartitService, VotsPerPartitService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //permite a CORS poder acceder desde esta urlrs
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazor", builder =>
                {
                    builder.WithOrigins("https://localhost:7028") // Replace with your Blazor WebAssembly origin
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            //Aqui es on em conecto a la Database
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //esto contruye la app tener en cuenta que cosas van antes o despues
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

            // Use CORS middleware
            app.UseCors("AllowBlazor");

            app.Run();
        }
    }
}
