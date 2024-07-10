using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IContactService:IGenericService<Contact>
    {
        Contact GetFirstContact();
        string GetFirstContactMapUrl();
    }
}