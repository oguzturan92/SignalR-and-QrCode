using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Concrete;
using Data.Repository;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.EntityFramework
{
    public class OrderDal : GenericRepository<Order>, IOrderDal
    {
        public OrderDal(Context context) : base(context)
        {
        }

        public Order OrderAndOrderLine(int tableId)
        {
            using (var context = new Context())
            {
                return context.Orders.Where(i => i.TableId == tableId && !i.OrderComplate)
                                    .Include(i => i.OrderLines)
                                    .FirstOrDefault();
            }
        }
    }
}