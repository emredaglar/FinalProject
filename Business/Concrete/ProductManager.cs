using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //ne inmemory nede entityfreamwork ismi geçecek
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //validation

            ValidationTool.Validate(new ProductValidator(), product);



            _productDal.Add(product);
            //if (product.ProductName.Length<2)
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}

            //add i geçmiş mutlu. şimdi result çalıştırabilir
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> getAll()
        {
            //İş kodları
            //iş kodlarından geçtiğini varsayıyoruz.
            //ifler vs. yetkisi var mı? varsa.-->

            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //return _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

        }
        //----------------------sonrası----------------//
        public IDataResult<List<Product>> getAllByCategoryId(int id)
        {//( )  bana bir lambda yani kural ver diyor.
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> getById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }

        public IDataResult<List<Product>> getByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetail());
        }
    }
}
