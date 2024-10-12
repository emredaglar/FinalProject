using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        //List<Product> getAll();
        IDataResult<List<Product>> getAll(); //T olark list p koytduk

        //kategori idye göre getir.
        IDataResult<List<Product>> getAllByCategoryId(int id);
        //şu fiyat aralığında olan ürünleri getir.
        IDataResult<List<Product>> getByUnitPrice(decimal min,decimal max);
        IDataResult<Product>getById(int id);
        //ıresuklt sadece voşdker içindi
        IResult Add(Product product);
        IDataResult<List<ProductDetailDto>> GetProductDetails();

    }
}
