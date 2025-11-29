using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactServices
    {
        IContact _contact;

        public ContactManager(IContact contact)
        {
            _contact = contact;
        }
        public void Add(Contact t)
        {
            _contact.Add(t);
        }

        public void Delete(Contact t)
        {
            _contact.Delete(t);
        }

        public Contact GetById(int id)
        {
            var entity = _contact.GetById(id);

            return entity;
        }

        public List<Contact> GetList()
        {
            return _contact.GetList();
        }

        public void Update(Contact t)
        {
            _contact.Update(t);
        }
    }
}
