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
    public class EFFeature : GenericRepository<Feature>, IFeature
    {
        private readonly DBContext c;
        public EFFeature(DBContext c) : base(c)
        {
            this.c = c;
        }
    }
}
