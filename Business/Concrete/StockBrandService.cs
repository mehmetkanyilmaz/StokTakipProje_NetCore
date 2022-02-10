using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StockBrandService : IStockBrandService
    {
        IStockBrandDal _stockBrandDal;
        public StockBrandService(IStockBrandDal stockBrandDal)
        {
            _stockBrandDal = stockBrandDal;
        }
        public IDataResult<List<Stock_Brand>> GetList()
        {
            var result = _stockBrandDal.GetList().ToList();
            if (result == null)
                return new ErrorDataResult<List<Stock_Brand>>();
            return new SuccessDataResult<List<Stock_Brand>>(result);
        }
    }
}
