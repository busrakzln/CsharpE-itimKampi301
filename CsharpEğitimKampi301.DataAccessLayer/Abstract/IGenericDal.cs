using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEğitimKampi301.DataAccessLayer.Abstract
{
    public interface IGenericDal<T>where T : class
    {
        //bu işlemle bütün entitylere özgü bu yüzden generic
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
        T GetById(int id);
    }
}
