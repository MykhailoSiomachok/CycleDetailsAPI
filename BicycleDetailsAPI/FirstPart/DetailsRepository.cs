using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LowerLayer
{
    public class DetailsRepository : IRepository<BicycleDetail>
    {
        private readonly DBContext dbContext;
        public DetailsRepository()
        {
            dbContext = new DBContext();
        }
        public IEnumerable<BicycleDetail> GetDetails(PageSettings page)
        {
            if (page?.PageSize != null)
            {
                IEnumerable<BicycleDetail> details = dbContext.Details.Skip((page.PageNumber - 1) * page.PageSize).Take(page.PageSize).ToList();
                if (page.FilterString != null)
                {
                    details = (from BicycleDetail detail in details
                               where detail.Type == page.FilterString
                               || detail.Material == page.FilterString ||
                               detail.Producer == page.FilterString ||
                               detail.Color == page.FilterString ||
                               detail.Brand == page.FilterString
                               select detail).ToList();
                }
                switch (page.SortOrder)
                {
                    case "type_desc":
                        details = details.OrderByDescending(s => s.Type);
                        break;
                    case "country_desc":
                        details = details.OrderByDescending(s => s.Producer);
                        break;
                    case "country_asc":
                        details = details.OrderBy(s => s.Producer);
                        break;
                    default:
                        details = details.OrderBy(s => s.Type);
                        break;
                }
                return details;
            }
            else
            {
                return dbContext.Details;
            }
        }

        public BicycleDetail GetDetail(int id) => dbContext.Details.Find(id);
        public void Create(BicycleDetail detail) => dbContext.Details.Add(detail);
        public void Update(BicycleDetail detail)
        {
            dbContext.Entry(detail).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
           BicycleDetail detail = dbContext.Details.Find(id);
            if(detail != null)
            {
                dbContext.Details.Remove(detail);
            }
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
