using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileOperation.Models
{
    public enum FlowStatus
    {
        已派发,
        已阅读,
        待处理,
        已完成,
        无法完成,
        超时
    }

    public class FlowExecutor
    {
        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("Flow")]
        public Guid FlowId { get; set; }

        public Flow Flow { get; set; }

        public FlowStatus Status { get; set; }

        public string Content { get; set; }

        public DateTime? ReadTime { get; set; }

        public DateTime? ExecutingTime { get; set; }

        public DateTime? ExecutedTime { get; set; }
    }
}
