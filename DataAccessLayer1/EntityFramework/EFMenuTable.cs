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
    public class EFMenuTable : GenericRepository<MenuTable>, IMenuTables
    {
        public int MenuTableCount()
        {
            using var c = new DBContext();

            var entity = c.MenuTables.Where(N=>N.Status==true).Count();

            return entity;
        }
    }
}
