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
    public class OrderLineDal : GenericRepository<OrderLine>, IOrderLineDal
    {
        public OrderLineDal(Context context) : base(context)
        {
        }

        public OrderLine GetOrderLine(int orderId, string productName)
        {
            using (var context = new Context())
            {
                return context.OrderLines.Where(i => i.ProductName == productName && i.OrderId == orderId).FirstOrDefault();
            }
        }
    }
}