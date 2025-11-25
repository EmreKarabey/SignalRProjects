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
            throw new NotImplementedException();
        }

        public Booking GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(Booking t)
        {
            throw new NotImplementedException();
        }
    }
}
