using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class TableManager : ITableService
    {
        private readonly ITableDal _tableDal;

        public TableManager(ITableDal tableDal)
        {
            _tableDal = tableDal;
        }

        public void Create(Table entity)
        {
            _tableDal.Create(entity);
        }

        public void Delete(Table entity)
        {
            _tableDal.Delete(entity);
        }

        public List<Table> GetAll()
        {
            return _tableDal.GetAll();
        }

        public Table GetById(int id)
        {
            return _tableDal.GetById(id);
        }

        public List<Table> GetTablesStatusTrue()
        {
            return _tableDal.GetTablesStatusTrue();
        }

        public void Update(Table entity)
        {
            _tableDal.Update(entity);
        }
    }
}