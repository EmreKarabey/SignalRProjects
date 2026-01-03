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
    public class MoneyCaseManager : IMoneyCaseService
    {
        IMoneyCase _moneyCase;

        public MoneyCaseManager(IMoneyCase moneyCase)
        {
            _moneyCase = moneyCase;
        }

        public void Add(MoneyCase t)
        {
            _moneyCase.Add(t);
        }

        public void Delete(MoneyCase t)
        {
            _moneyCase.Delete(t);
        }

        public MoneyCase GetById(int id)
        {
            return _moneyCase.GetById(id);
        }

        public List<MoneyCase> GetList()
        {
            return _moneyCase.GetList();
        }

        public decimal SumCase()
        {
            return _moneyCase.SumCase();
        }

        public void Update(MoneyCase t)
        {
            _moneyCase.Update(t);
        }
    }
}
