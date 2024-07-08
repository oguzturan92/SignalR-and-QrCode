using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IOrderLineService:IGenericService<OrderLine>
    {
        OrderLine GetOrderLine(int orderId, string productName);
    }
}