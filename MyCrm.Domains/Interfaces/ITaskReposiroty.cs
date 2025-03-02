using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Actions;
using MyCrm.Domains.Entities.Tasks;

namespace MyCrm.Domains.Interfaces
{
  
     public interface ITaskRepository
    {
        Task AddTask(CrmTask task);
        Task UpdateTask(CrmTask task);
        Task<CrmTask> GetTaskById(long taskId);
        Task<IQueryable<CrmTask>> GetTasksQueryable();

        Task SaveChanges();

        #region Marketing Action

        Task AddAction(MarketingAction action);

        Task UpdateAction(MarketingAction action);

        Task<MarketingAction> GetActionById(long actionId);

        Task<IQueryable<MarketingAction>> GetActionsQueryable();

        #endregion
    }
}
