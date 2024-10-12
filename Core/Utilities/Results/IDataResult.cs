using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //hangi tipi döndüreceğini bana söyle. hem data hem mesaj istiyor. e mesajı zaten Iresult içeriyor. ozaman imp et.
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
