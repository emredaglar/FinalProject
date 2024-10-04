using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //ne inmemory nede entity freamwork ismi geçecek
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> getAll()
        {
            //İş kodları
            //iş kodlarından geçtiğini varsayıyoruz.
            //ifler vs. yetkisi var mı? varsa.-->

            return _productDal.GetAll();
        }
        //----------------------sonrası----------------//
        public List<Product> getAllByCategoryId(int id)
        {//( )  bana bir lambda yani kural ver diyor.
            return _productDal.GetAll(p=>p.CategoryId == id);
        }

        public List<Product> getByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
