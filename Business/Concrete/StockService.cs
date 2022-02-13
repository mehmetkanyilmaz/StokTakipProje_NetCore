using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StockService : IStockService
    {
        private IStockDal _stockDal;
        public StockService(IStockDal stockDal)
        {
            _stockDal = stockDal;
        }

        public IDataResult<Stock> Add(Stock stock)
        {
            //Send data control
            if (String.IsNullOrEmpty(stock.name))
                return new ErrorDataResult<Stock>(Messages.StockNameEmpty);

            if (String.IsNullOrEmpty(stock.group.ToString()) || stock.group <= 0)
                return new ErrorDataResult<Stock>(Messages.StockGroupEmpty);

            if (String.IsNullOrEmpty(stock.brand.ToString()) || stock.brand <= 0)
                return new ErrorDataResult<Stock>(Messages.StockBrandEmpty);

            if (String.IsNullOrEmpty(stock.model.ToString()) || stock.model <= 0)
                return new ErrorDataResult<Stock>(Messages.StockModelEmpty);

            if (String.IsNullOrEmpty(stock.unit_price.ToString()) || stock.unit_price <= 0)
                return new ErrorDataResult<Stock>(Messages.StockUnitPriceEmpty);

            if (String.IsNullOrEmpty(stock.quantity.ToString()) || stock.quantity <= 0)
                return new ErrorDataResult<Stock>(Messages.StockQuantityEmpty);

            if (String.IsNullOrEmpty(stock.status.ToString()))
                return new ErrorDataResult<Stock>(Messages.StockStatusEmpty);

            if (String.IsNullOrEmpty(stock.cuser.ToString()) || String.IsNullOrEmpty(stock.muser.ToString()))
                return new ErrorDataResult<Stock>(Messages.UserNotFound);

            //Stock add
            var result = _stockDal.Add(stock);
            if (result == null)
                return new ErrorDataResult<Stock>();
            return new SuccessDataResult<Stock>(result, Messages.StockAddSuccessful);

        }

        public IResult Delete(Stock stock)
        {
            if (String.IsNullOrEmpty(stock.id.ToString()))
                return new ErrorResult(Messages.StockIdEmpty);

            _stockDal.Delete(stock);
            return new SuccessResult();
        }

        public IDataResult<Stock> Get(int stockId)
        {
            if (String.IsNullOrEmpty(stockId.ToString()) || stockId <= 0)
                return new ErrorDataResult<Stock>(Messages.StockIdEmpty);

            var result = _stockDal.Get(x => x.id == stockId);
            if(result == null)
                return new ErrorDataResult<Stock>(Messages.StockNotFound);
            return new SuccessDataResult<Stock>(result);
        }

        public IDataResult<List<Stock>> GetList()
        {
            var result = _stockDal.GetList();
            if (result == null)
                return new ErrorDataResult<List<Stock>>(Messages.StockListError);

            return new SuccessDataResult<List<Stock>>(result.ToList());
        }

        public IDataResult<List<StockListDto>> GetListDto()
        {
            var result = _stockDal.StockList();
            if (result == null)
                return new ErrorDataResult<List<StockListDto>>();
            return new SuccessDataResult<List<StockListDto>>(result);
        }

        public IDataResult<Stock> Update(Stock stock)
        {
            if (String.IsNullOrEmpty(stock.id.ToString()))
                return new ErrorDataResult<Stock>(Messages.StockIdEmpty);

            var result = _stockDal.Update(stock);
            if (result == null)
                return new ErrorDataResult<Stock>(Messages.StockUpdateError);
            return new SuccessDataResult<Stock>(Messages.StockUpdateSuccessful);
        }
    }
}
