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
    public class BookingManager : IBookingServices
    {
        IBooking _booking;

        public BookingManager(IBooking booking)
        {
            _booking = booking;
        }
        public void Add(Booking t)
        {
            _booking.Add(t);
        }

        public void Delete(Booking t)
        {
            _booking.Delete(t);
        }

        public Booking GetById(int id)
        {
            var entity = _booking.GetById(id);

            return entity;
        }

        public List<Booking> GetList()
        {
            return _booking.GetList();
        }

        public void Update(Booking t)
        {
            _booking.Update(t);
        }
    }
}
