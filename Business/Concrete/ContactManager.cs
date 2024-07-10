using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Create(Contact entity)
        {
            _contactDal.Create(entity);
        }

        public void Delete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public List<Contact> GetAll()
        {
            return _contactDal.GetAll();
        }

        public Contact GetById(int id)
        {
            return _contactDal.GetById(id);
        }

        public Contact GetFirstContact()
        {
            return _contactDal.GetFirstContact();
        }

        public string GetFirstContactMapUrl()
        {
            return _contactDal.GetFirstContactMapUrl();
        }

        public void Update(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}