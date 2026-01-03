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

        private readonly DBContext c;

        public EFMenuTable(DBContext c): base (c)
        {
            this.c = c;
        }

        public MenuTable GetMenuMasaName(string masano)
        {

            var entity = c.MenuTables.Where(n => n.Name == masano).FirstOrDefault();

            return entity;
        }

        public int MenuTableCount()
        {

            var entity = c.MenuTables.Where(N=>N.Status==true).Count();

            return entity;
        }

        public void UpdateFalse(int id)
        {

            var entity = c.MenuTables.Where(n => n.MenuTableID == id).FirstOrDefault();

            entity.Status = false;

            c.MenuTables.Update(entity);

            c.SaveChanges();
        }

        public void UpdateTrue(int id)
        {
            var entity = c.MenuTables.Where(n => n.MenuTableID == id).FirstOrDefault();

            entity.Status = true;

            c.MenuTables.Update(entity);

            c.SaveChanges();
        }
    }
}
