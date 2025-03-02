using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Account;

namespace MyCrm.Domains.Entities.Events
{
    public class Event
    {
        [Key]
        public long EventId { get; set; }
        public long UserId { get; set; }
        public EventType EventType { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DataType CreateDate { get; set; }
        public DateTime EventDate { get; set; }
        public bool IsDelete { get; set; }
        #region Relations
        public User User { get; set; }
        #endregion

    }
    public enum EventType
    {
        [Display(Name = "HOshh")]
        Alert
    }
}
