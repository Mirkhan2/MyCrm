using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCrm.Data.Context;
using MyCrm.Domain.Entities.Predict;
using MyCrm.Domain.Interfaces;

namespace MyCrm.Data.Repository
{
    public class PredictRepository : IPredictRepository
    {
        #region Ctor
        private readonly CrmContext _context;
        public PredictRepository(CrmContext context)
        {
                _context = context;
        }
        #endregion
        public async Task AddPredictMarketer(PredictMarketer marketer)
        {
            await _context.AddAsync(marketer);
        }

        public async Task DeletePredictMarketer(PredictMarketer marketer)
        {
             _context.PredictMarketers.Remove(marketer);
        }

        public async Task<PredictMarketer> GetPredictMarketerById(long id)
        {
            return await _context.PredictMarketers.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IQueryable<PredictMarketer>> GetPredictMarketersQueryable()
        {
            return _context.PredictMarketers.AsQueryable();
            //return _context.OrderSelectedMarketers
            //    .Include(a => a.Order)
            //    .ThenInclude(a => a.Customer)
            //    .ThenInclude(a => a.User)
            //    .Include(a => a.Marketer)
            //    .ThenInclude(a => a.User)
            //    .AsQueryable();
        }

        public async Task SaveChange()
        {
            _context.SaveChanges();
        }

        public async Task UpdatePredictMarketer(PredictMarketer marketer)
        {
            _context.PredictMarketers.Update(marketer);
        }
    


    }
}
