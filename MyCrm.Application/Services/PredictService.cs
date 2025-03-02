using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCrm.Application.Interfaces;
using MyCrm.Domains.Entities.Account;
using MyCrm.Domains.Entities.Predict;
using MyCrm.Domains.Interfaces;
using MyCrm.Domains.ViewModels.Predict;

namespace MyCrm.Application.Services
{
    public class PredictService : IPredictService
    {
        #region Ctor
        private readonly IPredictRepository _predictRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;

        public PredictService(IPredictRepository predictRepository, IUserRepository userRepository,IOrderRepository orderRepository)
        {
            _predictRepository = predictRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;

        }

   
        #endregion

        public async Task<bool> ProcessMarketerPredict()
        {
            var marketers = await _userRepository.GetMarketerQueryable().Result.Where(a =>!a.IsDelete).ToListAsync();

            var process = new List<PredictMarketerResult>();

            foreach (var marketer in marketers)
            {
                int ZigmaDegree = 0;
                int allFinishedOrdersCount = 0;

                var orderMarketer = await _orderRepository.GetOrderSelectedMarkets().Result
                    .Where(a => a.MarketerId == marketer.UserId )
                    .Select(a => a.Order)
                    .Where(a => a.IsFinish && !a.IsDelete && a.EndDate !=null)
                    .ToListAsync();

                foreach (var order in orderMarketer)
                {
                    var timeLeft = order.EndDate.Value - order.CreateDate;

                    var predictDay = order.PredictDay;

                    ZigmaDegree += (predictDay - timeLeft.Days);
                    allFinishedOrdersCount +=1;
                }
                if (allFinishedOrdersCount == 0)
                {
                    continue;
                }

                float  deviation = ZigmaDegree / allFinishedOrdersCount;

                process.Add(new PredictMarketerResult()
                {
                    MarketerId = marketer.UserId,
                    Deviation =deviation
                });

            }
            var resultDeviation = process.OrderBy(a => a.Deviation).FirstOrDefault();
            if (resultDeviation == null)
            {
                return false;
            }

            await DeleteAllMarketerPredict();

            var predictMarketer = new PredictMarketer()
            {
                MarketerId = resultDeviation.MarketerId
            };
            await _predictRepository.AddPredictMarketer(predictMarketer);
            await _predictRepository.SaveChange();

            return true;
        }

        public async Task DeleteAllMarketerPredict()
        {
            var predicts = await _predictRepository.GetPredictMarketersQueryable().Result.ToListAsync();
           
            foreach (var predictMarketer in predicts)
            {
            await _predictRepository.DeletePredictMarketer(predictMarketer);
            }
            await _predictRepository.SaveChange();

        }

        public async Task<Marketer> GetMarketerPredict()
        {
            var marketerPredict = await _predictRepository.GetPredictMarketersQueryable().Result.FirstOrDefaultAsync(); 
            if (marketerPredict == null)
            {
                return null;
            }


            var result = await _userRepository
                .GetMarketerById(marketerPredict.MarketerId);
            return result;
        }
    }
}
