﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Tasks;

namespace MyCrm.Domains.ViewModels.Tasks
{
    public class TaskDetailViewModel
    {
        public CrmTask Task { get; set; }
        public int ActionCount { get; set; }

        public List<Entities.Actions.MarketingAction> MarketingActions { get; set; }


    }
}
