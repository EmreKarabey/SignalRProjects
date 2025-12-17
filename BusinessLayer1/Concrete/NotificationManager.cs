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
    public class NotificationManager : INotificationServices
    {
        INotification _notification;

        public NotificationManager(INotification notification)
        {
            _notification = notification;
        }
        public void Add(Notification t)
        {
            _notification.Add(t);
        }

        public void Delete(Notification t)
        {
            _notification.Delete(t);
        }

        public Notification GetById(int id)
        {
            return _notification.GetById(id);
        }

        public List<Notification> GetList()
        {
            return _notification.GetList();
        }

        public int NotificationCount()
        {
            return _notification.NotificationCount();
        }

        public void Update(Notification t)
        {
            _notification.Update(t);
        }
    }
}
