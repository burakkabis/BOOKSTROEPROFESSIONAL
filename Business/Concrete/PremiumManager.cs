using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PremiumManager : IPremiumService
    {
        IPremiumDal _premiumDal;

        public PremiumManager(IPremiumDal premiumDal)
        {
            _premiumDal = premiumDal;
        }

        public void Add(Premium Premium)
        {
            _premiumDal.Add(Premium);
        }
    }
}
