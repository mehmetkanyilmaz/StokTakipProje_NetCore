using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contants
{
    public static class Messages
    {
        //General
        public static string NullOrEmpty = "Submitted values ​​cannot be empty.";

        //User
        public static string UserNotFound = "User not found.";

        //Stock
        public static string StockNameEmpty = "Stock name empty.";
        public static string StockGroupEmpty = "Stock group empty.";
        public static string StockBrandEmpty = "Stock brand empty.";
        public static string StockModelEmpty = "Stock model empty.";
        public static string StockUnitPriceEmpty = "Stock unit price empty.";
        public static string StockStatusEmpty = "Stock status empty.";
        public static string StockQuantityEmpty = "Stock quantity empty.";
        public static string StockIdEmpty = "Stock id emtyp.";
        public static string StockNotFound = "Stock not found.";
        public static string StockEntry = "Stock entry.";
        public static string StockAddSuccessful = "Stock add successful.";
        public static string StockUpdateError = "Stock update error.";
        public static string StockUpdateSuccessful = "Stock update successful.";
        public static string StockListError = "Could not access stock list.";

        //Customer
        public static string CustomerEmpty = "Customer empty.";
        public static string StockMoveAddError = "Stock move add error.";
        public static string StockMoveAddSuccessful = "Stock move add successful.";

        //Common Functşons
        public static string FileEmpty = "File is empty.";
        public static string Path = "Path is empty.";
    }
}
