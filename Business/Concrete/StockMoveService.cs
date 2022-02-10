using Business.Abstract;
using Business.Contants;
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
    public class StockMoveService : IStockMoveService
    {
        private IStockMoveDal _stockMoveDal;
        public StockMoveService(IStockMoveDal stockMoveDal)
        {
            _stockMoveDal = stockMoveDal;
        }
        public IDataResult<Stock_Move> Add(Stock_Move stock_Move)
        {
            //Send data control
            if (String.IsNullOrEmpty(stock_Move.stock.ToString()) || stock_Move.stock <= 0)
                return new ErrorDataResult<Stock_Move>(Messages.StockIdEmpty);

            if (String.IsNullOrEmpty(stock_Move.customer.ToString()))
                return new ErrorDataResult<Stock_Move>(Messages.CustomerEmpty);

            if (String.IsNullOrEmpty(stock_Move.quantity.ToString()) || stock_Move.quantity <= 0)
                return new ErrorDataResult<Stock_Move>(Messages.StockQuantityEmpty);

            if (String.IsNullOrEmpty(stock_Move.unit_price.ToString()) || stock_Move.unit_price <= 0)
                return new ErrorDataResult<Stock_Move>(Messages.StockUnitPriceEmpty);

            if (String.IsNullOrEmpty(stock_Move.cuser.ToString()))
                return new ErrorDataResult<Stock_Move>(Messages.UserNotFound);

            //Stock move save 
            var result = _stockMoveDal.Add(stock_Move);
            if (result == null)
                return new ErrorDataResult<Stock_Move>(Messages.StockMoveAddError);
            return new SuccessDataResult<Stock_Move>(result, Messages.StockMoveAddSuccessful);
        }

        public IDataResult<List<Stock_Move>> GetList()
        {
            //TODO Devam et
            throw new NotImplementedException();
        }
    }
}
