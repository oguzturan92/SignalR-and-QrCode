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
    public class TableDal : GenericRepository<Table>, ITableDal
    {
        public TableDal(Context context) : base(context)
        {
        }

        public List<Table> GetTablesStatusTrue()
        {
            using (var context = new Context())
            {
                return context.Tables.Where(i => i.TableStatus).ToList();
            }
        }
    }
}