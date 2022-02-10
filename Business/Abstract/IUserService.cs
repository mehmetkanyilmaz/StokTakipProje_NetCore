using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        public IDataResult<User> Login(string code, string password);
        public IDataResult<List<User>> GetList();
    }
}
