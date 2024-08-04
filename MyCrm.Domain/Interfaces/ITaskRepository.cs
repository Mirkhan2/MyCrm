using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.Entities.Tasks;

namespace MyCrm.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<CrmTask> GetTaskById(long taskId);
        Task AddTask(CrmTask task);
        Task SaveChange();

        Task DeleteTask(long taskId);
        Task UpdateTask(CrmTask task);
        Task<IQueryable<CrmTask>> GetTasksQueryable();
        //Task DeleteTaskById(long taskId);
        //Task UpdateTaskById(Task task);

    }
}
