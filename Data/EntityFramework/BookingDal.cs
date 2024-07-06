using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Concrete;
using Data.Repository;
using Entity.Concrete;

namespace Data.EntityFramework
{
    public class BookingDal : GenericRepository<Booking>, IBookingDal
    {
        public BookingDal(Context context) : base(context)
        {
        }

        public int BookingCount()
        {
            using (var context = new Context())
            {
                return context.Bookings.Count();
            }
        }
    }
}