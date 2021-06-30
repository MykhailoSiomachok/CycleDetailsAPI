using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowerLayer
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<BicycleDetail> GetDetails(PageSettings page);
        BicycleDetail GetDetail(int id);
        void Create(BicycleDetail detail);
        void Update(BicycleDetail detail);
        void Delete(int id);
        void Save();
    }

}
