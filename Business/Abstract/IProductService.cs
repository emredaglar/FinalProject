using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> getAll();
        //kategori idye göre getir.
        List<Product> getAllByCategoryId(int id);
        //şu fiyat aralığında olan ürünleri getir.
        List<Product> getByUnitPrice(decimal min,decimal max);

    }
}
