using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MenuTablesManager : IMenuTablesServices
    {
        IMenuTables _menuTables;

        public MenuTablesManager(IMenuTables menuTables)
        {
            _menuTables = menuTables;
        }
        public void Add(MenuTable t)
        {
            _menuTables.Add(t);
        }

        public void Delete(MenuTable t)
        {
            _menuTables.Delete(t);
        }

        public MenuTable GetById(int id)
        {
            return _menuTables.GetById(id);
        }

        public List<MenuTable> GetList()
        {
            return _menuTables.GetList();
        }

        public MenuTable GetMenuMasaName(string masano)
        {
            return _menuTables.GetMenuMasaName(masano);
        }

        public int MenuTableCount()
        {
            return _menuTables.MenuTableCount();
        }

        public void Update(MenuTable t)
        {
            _menuTables.Update(t);
        }
    }
}
