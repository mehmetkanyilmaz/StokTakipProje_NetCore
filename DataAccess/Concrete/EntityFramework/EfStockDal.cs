using Core.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStockDal : EfEntityRepositoryBase<Stock, StockTrackingContext>, IStockDal
    {
        public List<StockListDto> StockList()
        {
            using (var context = new StockTrackingContext())
            {
                List<StockListDto> result = (from stock in context.TBL_STOCK
                                               join stock_group in context.TBL_STOCK_GROUP on stock.@group equals stock_group.id
                                               join stock_brand in context.TBL_STOCK_BRAND on stock.brand equals stock_brand.id
                                               join stock_model in context.TBL_STOCK_MODEL on stock.model equals stock_model.id
                                               select new StockListDto
                                               {
                                                   id = stock.id,
                                                   name = stock.name,
                                                   brand_name = stock_brand.name,
                                                   group_name = stock_group.name,
                                                   model_name = stock_model.name,
                                                   unit_price = stock.unit_price,
                                                   quantity   = stock.quantity,
                                                   image      = stock.image,
                                                   status     = stock.status,
                                                   cuser      = stock.cuser,
                                                   cdate      = stock.cdate,
                                                   muser      = stock.muser,
                                                   mdate      = stock.mdate
                                               }).ToList();

                return result;
            }
        }
    }
}
