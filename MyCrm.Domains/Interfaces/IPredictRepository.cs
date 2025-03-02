using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Predict;

namespace MyCrm.Domains.Interfaces
{
    public interface IPredictRepository
    {
        Task AddPredictMarketer(PredictMarketer marketer);
        Task UpdatePredictMarketer(PredictMarketer marketer);
        // void RemovePredictMarketer();
        Task<PredictMarketer> GetPredictMarketerById(long id);
        Task<IQueryable<PredictMarketer>> GetPredictMarketersQueryable();
        Task DeletePredictMarketer(PredictMarketer marketer);
        Task SaveChange();
    }
}
