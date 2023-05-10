using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public class Product:BaseEntity
    {

        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        //EF CORE foreing key olarak algılaması için aşağıdaki gibi vermek zorundayız ya da [ForeqignKey("Category_Id")] olarak yazıcaz
        public int CategoryId{ get; set; }

        public Category Category { get; set; }

        public ProductFeature ProductFeature { get; set; }


    }
}
