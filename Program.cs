using API_TD1_1.Models.DataManager;
using API_TD1_1.Models.EntityFramework;
using API_TD1_1.Models.Repository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using API_TD1_1.Models.DTO;
using API_TD1_1.Models.Repository.ProduitRepository;
using API_TD1_1.Models.Repository.MarqueRepository;
using API_TD1_1.Models.Repository.TypeProduitRepository;
using Microsoft.Net.Http.Headers;

namespace API_TD1_1
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

            builder.Services.AddDbContext<ProduitDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ProduitDBContext")));
            builder.Services.AddScoped<IDataRepository<Produit>, ProduitManager>();
            builder.Services.AddScoped<IDataRepositoryProduitDetailDTO, ProduitManager>();
            builder.Services.AddScoped<IDataRepositoryProduitDTO, ProduitManager>();

            builder.Services.AddScoped<IDataRepository<Marque>, MarqueManager>();
            builder.Services.AddScoped<IDataRepositoryMarqueDTO, MarqueManager>();

            builder.Services.AddScoped<IDataRepository<TypeProduit>, TypeProduitManager>();
            builder.Services.AddScoped<IDataRepositoryTypeProduitDTO, TypeProduitManager>();


            builder.Services.AddAutoMapper(typeof(Program).Assembly);



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


            //app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}