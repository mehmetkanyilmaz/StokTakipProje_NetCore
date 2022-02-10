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
    public class StockModelService : IStockModelService
    {
        private IStockModelDal _stockModelDal;
        public StockModelService(IStockModelDal stockModelDal)
        {
            _stockModelDal = stockModelDal;
        }
        public IDataResult<List<Stock_Model>> GetList()
        {
            var result = _stockModelDal.GetList().ToList();
            if (result == null)
                return new ErrorDataResult<List<Stock_Model>>();
            return new SuccessDataResult<List<Stock_Model>>(result);
        }

        public IDataResult<List<Stock_Model>> GetListByBrand(int brandId)
        {
            var result = _stockModelDal.GetList(x => x.brand == brandId).ToList();
            if (result == null)
                return new ErrorDataResult<List<Stock_Model>>();
            return new SuccessDataResult<List<Stock_Model>>(result);
        }
    }
}
