using Core.Entities;
using Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFreamwork
{
    public class EfEntityRepositoryBase<TEntity,TContext> :IEntityRepository<TEntity>
        where TEntity : class,IEntity, new() 
        where TContext : DbContext,new()
    {
        public void Add(TEntity entity)
        //Entity Freamwork bir ORM dir.Veritabanındaki tabloları bir class gibi alıp VT işlerini yapabilir
        {
            //NorthwindContext işi bitince bellekten atılcak.IDisposable pattern implemetion of c#
            using (TContext context = new TContext())
            {
                //git veri tabanından benim verdiğimi eşleştir
                //ve ekle
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //git veri tabanından benim verdiğimi eşleştir
                //ve sil
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //null mı? değilse ? sonrasına çalışır.Producta yerleş ve oradaki tüm datayı listeye yerleştir.
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //git veri tabanından benim verdiğimi eşleştir
                //ve sil
                var uptatedEntity = context.Entry(entity);
                uptatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
