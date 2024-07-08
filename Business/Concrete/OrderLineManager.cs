using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class OrderLineManager : IOrderLineService
    {
        private readonly IOrderLineDal _orderLineDal;

        public OrderLineManager(IOrderLineDal orderLineDal)
        {
            _orderLineDal = orderLineDal;
        }

        public void Create(OrderLine entity)
        {
            _orderLineDal.Create(entity);
        }

        public void Delete(OrderLine entity)
        {
            _orderLineDal.Delete(entity);
        }

        public List<OrderLine> GetAll()
        {
            return _orderLineDal.GetAll();
        }

        public OrderLine GetById(int id)
        {
            return _orderLineDal.GetById(id);
        }

        public OrderLine GetOrderLine(int orderId, string productName)
        {
            return _orderLineDal.GetOrderLine(orderId, productName);
        }

        public void Update(OrderLine entity)
        {
            _orderLineDal.Update(entity);
        }
    }
}