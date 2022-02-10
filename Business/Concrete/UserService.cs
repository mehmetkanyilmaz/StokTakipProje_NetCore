using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Contants;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetList()
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Login(string code, string password)
        {
            //Gönderilen değerler kontrol ediliyor.
            if (String.IsNullOrEmpty(code) || String.IsNullOrEmpty(password))
                return new ErrorDataResult<User>(Messages.NullOrEmpty);

            var result = _userDal.Get(x => x.code == code && x.password == password);
            if (result == null)
                return new ErrorDataResult<User>(Messages.UserNotFound);

            return new SuccessDataResult<User>(result);
        }
    }
}
