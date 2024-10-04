using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //where kısmı generic constraint.Yani generic kısıt. sadece refarns tip alması için class yazdık. int vs olmamalı. , sadece Ientity i impelemente olan classları alabilir.
    //class:referans tip olması için,
    //IEntity yada IEntitiyi impelente eden
    //new(): newlenebilir olmalı. İnterfaci referans olarak alamaması için yazdık. Yani newlenemediği için sadece VT nesneleri ile çalışabilcek
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {

        //Hangi tipte çalışcağımızı yazacağım. T tipi. Önceden producttı yada category gibi.
        //filtreye göre getirme gibi kullanmak için Expression kullandık.filter=null filtre vermeyede bilirsin demek. filtre vermezsek hepsini getir anlamında.
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        //idye göre getirme gibi.Burda filtre zorunludur.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //kategoriye göre hepsini listeliycek.Kategoriye bastığında çıkacak kod
        //List<T> GetAllByCategory(int categoryId);
    }
}
