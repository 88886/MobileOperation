using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileOperation.Models
{
    public enum FlowType
    {
        一次性,
        每日,
        每周,
        每月
    }

    public class Flow
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreationTime { get; set; }

        [ForeignKey("Creator")]
        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public int AlarmTimeSpan { get; set; }

        public DateTime SpecificTime { get; set; }

        public FlowType Type { get; set; }

        public virtual ICollection<User> Executors { get; set; } = new List<User>();
    }
}
