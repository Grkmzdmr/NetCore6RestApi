using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        //Generic repository implemente etme sebebimiz IGenericRepositoryde ki bütün fonksiyonları orda kodladık o yüzden bir daha yazmamıza gerek yok.
        // Sadece IProductRepositorydeki fonksiyonları burda kodlayacağız






        public async Task<List<Product>> GetProductsWithCategory()
        {

            //Eager Loading yaptım productları cektigim anda kategoriyi çektim
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }


        



    }
}
