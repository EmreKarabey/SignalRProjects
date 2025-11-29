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
    public class FeatureManager : IFeatureServices
    {
        IFeature _feature;

        public FeatureManager(IFeature feature)
        {
            _feature = feature;
        }
        public void Add(Feature t)
        {
            _feature.Add(t);
        }

        public void Delete(Feature t)
        {
            _feature.Delete(t);
        }

        public Feature GetById(int id)
        {
            var entity = _feature.GetById(id);

            return entity;
        }

        public List<Feature> GetList()
        {
            return _feature.GetList();
        }

        public void Update(Feature t)
        {
            _feature.Update(t);
        }
    }
}
