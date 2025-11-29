using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericServices<T> where T : class
    {
        public void Add(T t);
        public void Delete(T t);
        public List<T> GetList();
        public void Update(T t);
        public T GetById(int id);
    }
}
