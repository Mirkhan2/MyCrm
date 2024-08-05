﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCrm.Data.Context;
using MyCrm.Domain.Entities.Tasks;
using MyCrm.Domain.Interfaces;
using MyCrm.Domain.ViewModels.Actions;

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

        public async Task AddAction(MarketingAction action)
        {
            await _context.AddAsync(action);
                }
        #endregion

        public async Task AddTask(CrmTask task)
        {
            await _context.AddAsync(task);
        }

        public Task DeleteAction(long taskId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTask(long taskId)
        {
            throw new NotImplementedException();
        }

        public async Task<MarketingAction> GetActionById(long actionId)
        {
            return await _context.MarketingActions.FirstOrDefaultAsync(a => a.ActionId == actionId);
        }

        public async Task<IQueryable<MarketingAction>> GetActionQueryable()
        {
            return _context.MarketingActions.AsQueryable();
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

        public async Task UpdateAction(MarketingAction action)
        {
            _context.MarketingActions.Update(action);
        }

        public async Task UpdateTask(CrmTask task)
        {
            _context.CrmTasks.Update(task);
        }

        async Task<CrmTask> ITaskRepository.GetTaskById(long taskId)
        {
            return await _context.CrmTasks.FirstOrDefaultAsync(a=> a.TaskId == taskId); 
        }
        public async Task<IQueryable<MarketingAction>> GetActionsQueryable()
        {
            return _context.MarketingActions.AsQueryable();
        }
    }
}