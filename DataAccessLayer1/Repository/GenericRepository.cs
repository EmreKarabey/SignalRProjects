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
        private readonly DBContext c;

        public GenericRepository(DBContext c)
        {
            this.c = c;
        }
        public void Add(T t)
        {
            c.Set<T>().Add(t);

            c.SaveChanges();
        }

        public void Delete(T t)
        {
            c.Set<T>().Remove(t);

            c.SaveChanges();

        }

        public T GetById(int id)
        {
            var entity = c.Set<T>().Find(id);

            return entity;
        }

        public List<T> GetList()
        {
            var list = c.Set<T>().ToList();

            return list;
        }

        public void Update(T t)
        {
            c.Set<T>().Update(t);

            c.SaveChanges();
        }
    }
}
