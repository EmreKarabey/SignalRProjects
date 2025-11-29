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
    public class CategoryManager : ICategoryServices
    {
        ICategory _category;

        public CategoryManager(ICategory category)
        {
            _category = category;
        }
        public void Add(Category t)
        {
            _category.Add(t);
        }

        public void Delete(Category t)
        {
            _category.Delete(t);
        }

        public Category GetById(int id)
        {
            return _category.GetById(id);
        }

        public List<Category> GetList()
        {
            return _category.GetList();
        }

        public void Update(Category t)
        {
            _category.Update(t);
        }
    }
}
