using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // Aynı sınıf içinde birden fazla constructor tanımlanabilir ve her biri farklı parametrelerle çağrılabilir.Buna "constructor overloading" denir.Bu durumda, iki farklı constructor var:

        //Biri iki parametre(success, message) alıyor.
        //Diğeri ise tek parametre(success) alıyor.
        //2. :this(success)
        //Bu ifade, bir constructor'ın başka bir constructor'ı çağırmasını sağlar.Yani, public Result(bool success, string message) constructor'ı, diğer constructor olan public Result(bool success)'i çağırıyor.

        //this(success) ifadesi, mevcut sınıfın diğer constructor'ını çağırır ve ona success parametresini gönderir.
        //Özetle, Result(bool success, string message) çalıştığında önce Result(bool success) constructor'ı çalışır.

        public Result(bool success, string message) : this(success)
        {
            Message = message;

        }
        public Result(bool success)
        {

            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
