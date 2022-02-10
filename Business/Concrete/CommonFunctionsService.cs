using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommonFunctionsService : ICommonFunctionsService
    {
        public IResult ImageSaveToServer(IFormFile file, string path = "wwwroot/images/")
        {

            if (String.IsNullOrEmpty(path))
                return new ErrorResult(Messages.Path);

            if(file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var imageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), path, imageName);
                var stream = new FileStream(location, FileMode.Create);
                file.CopyTo(stream);
                return new SuccessResult(imageName);
            }
            return new ErrorResult(Messages.FileEmpty);
        }
    }
}
