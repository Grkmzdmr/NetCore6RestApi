using NLayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface ICategoryService:IServices<Category>
    {
        public  Task<CustomResponseDTO<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductAsync(int categoryId);
        
        


    }
}
