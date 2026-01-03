using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFAppUser : GenericRepository<AppUser>, IAppUser
    {
        private readonly DBContext c;
        public EFAppUser(DBContext c) : base(c)
        {
            this.c = c;
        }
    }
}
