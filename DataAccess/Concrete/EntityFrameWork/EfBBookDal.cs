using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    //Book icin butun sql operasyonlari hazir.Sadece core dan implement ettik.
    public class EfBBookDal : EfEntityRepositoryBase<Book, BookContext>, IBookDal
    {

    }
}
