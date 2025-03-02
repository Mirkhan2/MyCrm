using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Events;

namespace MyCrm.Domains.ViewModels.Events
{
    public class AddEventViewModel
    {
        public EventType EventType { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string EventDate { get; set; }

    }

    public enum AddEventResult
    {
        Success,
        Fail
    }
}
