using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Core.Services;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Services;
using System.Reflection;
using AutoMapper;
using NLayer.Service.Mapping;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






builder.Services.AddScoped<IUnitOfWork, UnitOfWorks>();

builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

builder.Services.AddScoped(typeof(IServices<>), typeof(Service<>));

builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICategoryRepository,CategoryRepository >();
builder.Services.AddScoped<ICategoryService, CategoryService>();


//builder.Services.AddDbContext<AppDbContext>(optionsAction =>
//{
//    optionsAction.UseMySql(builder.Configuration.GetConnectionString("supermarketDB"),
//        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));
//});


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});




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
