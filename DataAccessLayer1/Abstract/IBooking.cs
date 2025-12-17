using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IBooking:IGeneric<Booking>
    {
        public void ChangeSuccess(Booking booking);
        public void ChangeCancel(Booking booking);
    }
}
