using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //temel voidler için başlangıç.
    //içerisinde bir işlem sonucu birtanede kulanıcıyı bilgilendirmek için bir mesaj.
    public interface IResult
    {
        bool Success { get; } //işlem sonucu başarılımı değilmi. sadece okunabilir yaptık.
        string Message { get; }//mesaj. doğru veya yanlış ise kullanıcıya mesaj yolla. neden başarısız gibi.



    }
}
