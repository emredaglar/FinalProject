using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
        ////Entity Freamwork bir ORM dir.Veritabanındaki tabloları bir class gibi alıp VT işlerini yapabilir
        //public void Add(Category entity)
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

        //public void Delete(Category entity)
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

        //public Category Get(Expression<Func<Category, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(Category entity)
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
    }
}
