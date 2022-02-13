using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class StockController : Controller
    {
        private IStockService _stockService;
        private IStockGroupService _stockGroupService;
        private IStockBrandService _stockBrandService;
        private IStockMoveService _stockMoveService;
        private ICommonFunctionsService _commonFunctionsService;
        public StockController(IStockService stockService, IStockGroupService stockGroupService, IStockBrandService stockBrandService, IStockMoveService stockMoveService, ICommonFunctionsService commonFunctionsService)
        {
            _stockService = stockService;
            _stockGroupService = stockGroupService;
            _stockBrandService = stockBrandService;
            _stockMoveService = stockMoveService;
            _commonFunctionsService = commonFunctionsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StockList()
        {
            var result = _stockService.GetListDto();
            StockListViewModel model = new StockListViewModel
            {
                stocks = result.Success == true ? result.Data : null
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var stockGroup = _stockGroupService.GetList();
            var stockBrand = _stockBrandService.GetList();
            StockAddViewModel stockAddViewModel = new StockAddViewModel() {
                groups = stockGroup.Success == true ? stockGroup.Data.ToList() : null,
                brands = stockBrand.Success == true ? stockBrand.Data.ToList() : null
            };
            return View(stockAddViewModel);
        }

        [HttpPost]
        public IResult Add(StockAddModel Data)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));//Logged user id

            Stock stock = new Stock()
            {
                name = Data.name,
                group = Data.group,
                brand = Data.brand,
                model = Data.model,
                unit_price = Data.unit_price,
                quantity = Data.quantity,
                status = true,
                cuser = userId,
                cdate = DateTime.Now.Date,
                muser = userId,
                mdate = DateTime.Now.Date
            };

            if (Data.image != null)
            {
                var imageAdd = _commonFunctionsService.ImageSaveToServer(Data.image);
                if (imageAdd.Success)
                    stock.image = imageAdd.Message;
            }

            var result = _stockService.Add(stock);
            if (result.Success)
            {
                Stock_Move stock_Move = new Stock_Move()
                {
                    stock = result.Data.id,
                    customer = 0,
                    move = false,
                    quantity = result.Data.quantity,
                    unit_price = result.Data.unit_price,
                    description = Messages.StockEntry,
                    cuser = result.Data.cuser,
                    cdate = result.Data.cdate
                };
                var stockMoveAdd = _stockMoveService.Add(stock_Move);
                if (stockMoveAdd.Success)
                    return new SuccessResult(stockMoveAdd.Message);
                return new ErrorResult(stockMoveAdd.Message);
            }
            return new ErrorResult(result.Message);
        }

        [HttpPost]
        public IResult Delete(int id)
        {
            //Check sent data
            if (String.IsNullOrEmpty(id.ToString()))
                return new ErrorResult(Messages.StockIdEmpty);


            //Stock check
            var stock = _stockService.Get(id);
            if (stock.Success == false)
                return new ErrorResult(Messages.StockNotFound);


            //Stock move list
            var stockMoveList = _stockMoveService.GetListByStockId(stock.Data.id);
            if (stockMoveList.Success == false)
                return new ErrorResult(Messages.StockMoveListError);


            //Sold product cannot be deleted from records
            if (stockMoveList.Data.Where(x => x.move == true).Count() > 0)
                return new ErrorResult(Messages.SoldStockDeleteError);


            //Stock move delete
            var stockMoveDelete = _stockMoveService.Delete(stockMoveList.Data);
            if (stockMoveDelete.Success == false)
                return new ErrorResult(Messages.StockMoveDeleteError);


            //Stock delete
            var stockDelete = _stockService.Delete(stock.Data);
            if (stockDelete.Success == false)
                return new ErrorResult(Messages.SoldStockDeleteError);


            return new SuccessResult(Messages.StockDeleteSuccessful);
        }

        [HttpGet]
        public IActionResult Update(int stockId)
        {
            var stock = _stockService.Get(stockId);
            var stockGroup = _stockGroupService.GetList();
            var stockBrand = _stockBrandService.GetList();

            StockUpdateViewModel stockUpdateViewModel = new StockUpdateViewModel()
            {
                stock = stock.Success == true ? stock.Data : null,
                groups = stockGroup.Success == true ? stockGroup.Data.ToList() : null,
                brands = stockBrand.Success == true ? stockBrand.Data.ToList() : null
            };

            return View(stockUpdateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IResult Update(Stock stock)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));//Logged user id

            stock.muser = userId;
            stock.mdate = DateTime.Now.Date;

            var stockUpdate = _stockService.Update(stock);
            return new Result(stockUpdate.Success, stockUpdate.Message);
        }

        public IActionResult StockModelByBrand(int brandId)
        {
            return ViewComponent("StockModel", new { brandId = brandId });
        }
    }
}
