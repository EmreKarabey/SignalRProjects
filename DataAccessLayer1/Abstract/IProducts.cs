using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IProducts:IGeneric<Products>
    {
        public List<Products> WithCategoryList();
        public Products IncludeGetById(int id);
    }
}
