using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStockMoveService
    {
        public IDataResult<Stock_Move> Add(Stock_Move stock_Move);
        public IDataResult<List<Stock_Move>> GetList();
        public IDataResult<List<Stock_Move>> GetListByStockId(int stockId);
        public IResult Delete(List<Stock_Move> stock_Move);
    }
}
