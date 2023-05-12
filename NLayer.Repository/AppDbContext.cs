using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {

        protected readonly IConfiguration Configuration;

      
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) :base(options)
        {
            Configuration = configuration;
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products{ get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }


      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Category class'ında primary key vermek istediğimiz yer için üstüne [Key] (İsmi Id'den farklıysa) yazabiliriz.
            //Ama kod temiz kalsın diye burada yapıyoruz.




            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id=1,
                Color="Kırmızı",
                Height=100,
                Width=200,
                ProductId=1

            },
            new ProductFeature()
            {
                Id=2,
                Color="Mavi",
                Height=300,
                Width=500,
                ProductId=2

            }
            );


            base.OnModelCreating(modelBuilder);
        }

    }
}
