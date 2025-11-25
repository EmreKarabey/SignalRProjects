using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;


namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {

        public void Add(T t)
        {
            using var c = new DBContext();

            c.Set<T>().Add(t);

            c.SaveChanges();
        }

        public void Delete(T t)
        {
            using var c = new DBContext();

            c.Set<T>().Remove(t);

            c.SaveChanges();

        }

        public T GetById(int id)
        {
            using var c = new DBContext();

            var entity = c.Set<T>().Find(id);

            return entity;
        }

        public void GetList()
        {
            using var c = new DBContext();

            c.Set<T>().ToList();
        }

        public void Update(T t)
        {
            using var c = new DBContext();

            c.Set<T>().Update(t);

            c.SaveChanges();
        }
    }
}
