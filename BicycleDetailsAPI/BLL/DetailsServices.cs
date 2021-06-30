using System;
using System.Collections.Generic;
using System.Linq;

using LowerLayer;

namespace BLL
{
    public class DetailsServices
    {
        private IRepository<BicycleDetail> repository;
        public DetailsServices()
        {
            repository = new DetailsRepository();
        }
        public IEnumerable<BicycleDetail> GetDetailsList(PageSettings page) => repository.GetDetails(page);
        public BicycleDetail GetDetail(int id) => repository.GetDetail(id);
        public string UpdateEntity(BicycleDetail detail)
        {
            if(DetailEntityValidation.IsEntityValid(detail))
            {
                repository.Update(detail);
                repository.Save();
                return "Object updated";
            }
            return "Object is not valid";
        }
        public string DeleteEntity(int id)
        {
            try
            {
                repository.Delete(id);
            }
            catch
            {
                return "Something went wrong";
            }
            finally
            {
                repository.Save();
            }
            return "Entity deleted";
        }
        public string AddEntity(BicycleDetail detail)
        {
            if (DetailEntityValidation.IsEntityValid(detail))
            {
                repository.Create(detail);
                repository.Save();
                return "Object created";
            }
            return "Object not valid";
        }
        public HashSet<string> GetColors(string type)
        {
            var result = (from detail in repository.GetDetails(null)
                          where detail.Type == type
                          select detail.Color).ToHashSet();
            return result;
        }
        public List<string> GetTypes(string color)
        {
            var result = (from detail in repository.GetDetails(null)
                          where detail.Color == color
                          select detail.Type).ToList();
            return result;
        }
    }
}
