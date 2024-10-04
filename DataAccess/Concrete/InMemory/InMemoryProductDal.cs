using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //global değişkenler _altçizgi ile isimlendirilir.
        //projeyi başlatınca bellekte bir ürün listesi oluştur.
        List<Product> _products;


        //bu class newlendiği anda çalış demek. constructor
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                //herhangi bir veritabanından geliyormuş gibi simule ettik.(oracle,sql ,postgress vs.)
                new Product { CategoryId = 1, ProductId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 10 },
                new Product { CategoryId = 1, ProductId = 2, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
                new Product { CategoryId = 2, ProductId = 3, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2 },
                new Product { CategoryId = 2, ProductId = 4, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65 },
                new Product { CategoryId = 2, ProductId = 5, ProductName = "Mouse", UnitPrice = 85, UnitsInStock = 1 },

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId==p.ProductId)
            //    {
            //        productToDelete = p;
            //    }

            //}
            //_products.Remove(productToDelete);
            ////LINQ olmasa böyle yazcaktık.
            //her idyi tek tek dolaş demek
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //Where:içindeki şarta uyan bütün elemanları yeni bir liste haline getirip onu döndürür.
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün idsine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            product.UnitsInStock = product.UnitsInStock;
        }
    }
}
