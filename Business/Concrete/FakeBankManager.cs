using Business.Abstract;
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
    public class FakeBankManager : IFakeBankService
    {
        IFakeBankDal _fakeBankDal;
        public FakeBankManager(IFakeBankDal fakeBankDal)
        {
            _fakeBankDal = fakeBankDal;
        }

        public IResult Add(FakeBank fakeBank)
        {
          
            _fakeBankDal.Add(fakeBank);
            return new SuccessResult();
        }
    }
}
