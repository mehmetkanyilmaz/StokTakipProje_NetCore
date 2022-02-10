using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStockModelService
    {
        public IDataResult<List<Stock_Model>> GetList();
        public IDataResult<List<Stock_Model>> GetListByBrand(int brandId);
    }
}
