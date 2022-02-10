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
    public class StockGroupService : IStockGroupService
    {
        private IStockGroupDal _stockGroupDal;
        public StockGroupService(IStockGroupDal stockGroupDal)
        {
            _stockGroupDal = stockGroupDal;
        }
        public IDataResult<List<Stock_Group>> GetList()
        {
            var result = _stockGroupDal.GetList().ToList();
            if (result == null)
                return new ErrorDataResult<List<Stock_Group>>();
            return new SuccessDataResult<List<Stock_Group>>(result);
        }
    }
}
