using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommonFunctionsService
    {
        public IResult ImageSaveToServer(IFormFile file, string path = "wwwroot/images/");
    }
}
