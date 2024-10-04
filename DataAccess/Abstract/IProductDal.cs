using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // Dal hangi katmana karşılık geldiği.Data Access Layer. Dao da denir.
    public interface IProductDal:IEntityRepository<Product>
    {
        //List<Product> GetAll();
        //void Add(Product product);
        //void Update(Product product);
        //void Delete(Product product);

        ////kategoriye göre hepsini listeliycek.Kategoriye bastığında çıkacak kod
        //List<Product> GetAllByCategory(int categoryId);
    }
}
