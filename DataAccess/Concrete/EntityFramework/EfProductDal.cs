using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //ıpordal bana kızma bunların hepsi base içinde var. ee neden Iprdal var? çünkü sadece efenrep tüm efler için bir base. biz sadece product için bir istek yaparsak ıproductdal içinde kullanacağız ve buraya yazacağız.
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        //    public void Add(Product product)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Delete(Product product)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public List<Product> GetAll()
        //    {
        //        return new List<Product> { new Product { ProductName="Tablo"}, new Product { ProductName = "Su" } };
        //    }

        //    public List<Product> GetAllByCategory(int categoryId)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Update(Product product)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public void Add(Product entity)
        ////Entity Freamwork bir ORM dir.Veritabanındaki tabloları bir class gibi alıp VT işlerini yapabilir
        //{
        //    //NorthwindContext işi bitince bellekten atılcak.IDisposable pattern implemetion of c#
        //    using (NorthwindContext context = new NorthwindContext())
        //    {
        //        //git veri tabanından benim verdiğimi eşleştir
        //        //ve ekle
        //        var addedEntity = context.Entry(entity);
        //        addedEntity.State = EntityState.Added;
        //        context.SaveChanges();
        //    }
        //}

        //public void Delete(Product entity)
        //{
        //    using (NorthwindContext context = new NorthwindContext())
        //    {
        //        //git veri tabanından benim verdiğimi eşleştir
        //        //ve sil
        //        var deletedEntity = context.Entry(entity);
        //        deletedEntity.State = EntityState.Deleted;
        //        context.SaveChanges();
        //    }
        //}

        //public Product Get(Expression<Func<Product, bool>> filter)
        //{
        //    using (NorthwindContext context = new NorthwindContext())
        //    {
        //        return context.Set<Product>().SingleOrDefault(filter);
        //    }
        //}

        //public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        //{
        //    using (NorthwindContext context = new NorthwindContext())
        //    {
        //        //null mı? değilse ? sonrasına çalışır.Producta yerleş ve oradaki tüm datayı listeye yerleştir.
        //        return filter == null
        //            ? context.Set<Product>().ToList()
        //            : context.Set<Product>().Where(filter).ToList();

        //    }
        //}

        //public void Update(Product entity)
        //{
        //    using (NorthwindContext context = new NorthwindContext())
        //    {
        //        //git veri tabanından benim verdiğimi eşleştir
        //        //ve sil
        //        var uptatedEntity = context.Entry(entity);
        //        uptatedEntity.State = EntityState.Modified;
        //        context.SaveChanges();
        //    }
        //}
        public List<ProductDetailDto> GetProductDetail()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();
            }
        }
    }
}
