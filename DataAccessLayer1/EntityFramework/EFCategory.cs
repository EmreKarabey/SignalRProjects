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
    public class EFCategory : GenericRepository<Category>, ICategory
    {
        public int ActiveCategory()
        {
            using var c = new DBContext();

            var entity = c.Categories.Where(N => N.CategoryStatus == true).Count();

            return entity;
        }

        public int CategoryCount()
        {
            using var c = new DBContext();

            var count = c.Categories.Count();

            return count;
        }

        public int PassiveCategory()
        {
            using var c = new DBContext();

            var entity = c.Categories.Where(N => N.CategoryStatus == false).Count();

            return entity;
        }
    }
}
