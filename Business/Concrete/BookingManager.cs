using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public int BookingCount()
        {
            return _bookingDal.BookingCount();
        }

        public void Create(Booking entity)
        {
            _bookingDal.Create(entity);
        }

        public void Delete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public List<Booking> GetAll()
        {
            return _bookingDal.GetAll();
        }

        public Booking GetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public void Update(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}