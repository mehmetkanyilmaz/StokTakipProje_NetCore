using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStockService
    {
        public IDataResult<List<StockListDto>> GetListDto();
        public IDataResult<List<Stock>> GetList();
        public IDataResult<Stock> Get(int stockId);
        public IDataResult<Stock> Add(Stock stock);
        public IDataResult<Stock> Update(Stock stock);
    }
}
