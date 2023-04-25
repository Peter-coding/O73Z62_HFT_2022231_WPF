using O73Z62_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O73Z62_HFT_2022231.Repository
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> ReadAll();
        T Read(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
