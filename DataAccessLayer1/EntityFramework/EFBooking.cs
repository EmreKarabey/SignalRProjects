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
    public class EFBooking : GenericRepository<Booking>, IBooking
    {
        public void ChangeCancel(Booking booking)
        {
            using var c = new DBContext();

            var entity = c.Bookings.Where(n => n.BookingID == booking.BookingID).FirstOrDefault();

            if (entity != null)
            {
                entity.Status = "Rezervasyon İptal Edildi";

                c.Bookings.Update(entity);
                c.SaveChanges();
            }

        }

        public void ChangeSuccess(Booking booking)
        {
            using var c = new DBContext();

            var entity = c.Bookings.Where(n => n.BookingID == booking.BookingID).FirstOrDefault();

            if (entity != null)
            {
                entity.Status = "Rezervasyon Onaylandı";

                c.Bookings.Update(entity);

                c.SaveChanges();
            }
        }
    }
}
