using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFNotification : GenericRepository<Notification>, INotification
    {
        private readonly DBContext c;

        public EFNotification(DBContext c): base(c)
        {
            this.c = c;
        }
        public int NotificationCount()
        {
            var count = c.Notifications.Where(n=>n.Status==false).Count();

            return count;
        }
    }
}
