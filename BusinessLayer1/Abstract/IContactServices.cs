using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContactServices:IGenericServices<Contact>
    {
    }
}
