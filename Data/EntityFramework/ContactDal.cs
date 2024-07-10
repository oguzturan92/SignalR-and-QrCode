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
    public class ContactDal : GenericRepository<Contact>, IContactDal
    {
        public ContactDal(Context context) : base(context)
        {
        }

        public Contact GetFirstContact()
        {
            using (var context = new Context())
            {
                return context.Contacts.FirstOrDefault();
            }
        }

        public string GetFirstContactMapUrl()
        {
            using (var context = new Context())
            {
                return context.Contacts.FirstOrDefault().ContactMap;
            }
        }
    }
}