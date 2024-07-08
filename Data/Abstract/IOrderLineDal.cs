using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Data.Abstract
{
    public interface IOrderLineDal:IGenericDal<OrderLine>
    {
        OrderLine GetOrderLine(int orderId, string productName);
    }
}