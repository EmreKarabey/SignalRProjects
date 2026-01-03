using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IMenuTables:IGeneric<MenuTable>
    {
        public int MenuTableCount();

        public MenuTable GetMenuMasaName(string masano);
        public void UpdateTrue(int id);
        public void UpdateFalse(int id);
    }
}
