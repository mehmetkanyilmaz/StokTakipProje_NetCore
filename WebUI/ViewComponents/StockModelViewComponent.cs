using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents
{
    public class StockModelViewComponent : ViewComponent
    {
        private IStockModelService _stockModelService;
        public StockModelViewComponent(IStockModelService stockModelService)
        {
            _stockModelService = stockModelService;
        }
        public ViewViewComponentResult Invoke(int brandId)
        {
            var model = _stockModelService.GetListByBrand(brandId).Data.ToList();
            return View(model);
        }
    }
}
