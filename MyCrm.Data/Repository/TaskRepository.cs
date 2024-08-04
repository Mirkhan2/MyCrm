using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCrm.Data.Context;
using MyCrm.Domain.Entities.Tasks;
using MyCrm.Domain.Interfaces;

namespace MyCrm.Data.Repository
{
    public class TaskRepository : ITaskRepository
    {
        #region ctor
        private readonly CrmContext _context;
        public TaskRepository(CrmContext context)
        {

            _context = context;

        }
        #endregion

        public async Task AddTask(CrmTask task)
        {
            await _context.AddAsync(task);
        }

        public Task DeleteTask(long taskId)
        {
            throw new NotImplementedException();
        }
        //FIxen
        public async Task<CrmTask> GetTaskById(long taskId)
        {
           return await _context.CrmTasks.FirstOrDefaultAsync(a => a.TaskId == taskId);
        }

        public Task<IQueryable<CrmTask>> GetTasksQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTask(CrmTask task)
        {
            _context.CrmTasks.Update(task);
        }

        async Task<CrmTask> ITaskRepository.GetTaskById(long taskId)
        {
            return await _context.CrmTasks.FirstOrDefaultAsync(a=> a.TaskId == taskId); 
        }
    }
}
