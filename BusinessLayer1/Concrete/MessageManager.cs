using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageServices
    {
        IMessage _message;

        public MessageManager(IMessage message)
        {
            _message = message;
        }
        public void Add(Message t)
        {
            _message.Add(t);
        }

        public void Delete(Message t)
        {
            _message.Delete(t);
        }

        public Message GetById(int id)
        {
            return _message.GetById(id);
        }

        public List<Message> GetList()
        {
            return _message.GetList();
        }

        public void Update(Message t)
        {
            _message.Update(t);
        }
    }
}
