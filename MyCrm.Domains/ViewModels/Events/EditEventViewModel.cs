using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Events;

namespace MyCrm.Domains.ViewModels.Events
{
    public class EditEventViewModel
    {
        public long EventId { get; set; }

        public EventType EventType { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string EventDate { get; set; }

    }

    public enum EditEventResult
    {
        Success,
        Fail
    }
}
