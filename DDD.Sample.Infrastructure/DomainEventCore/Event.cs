using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Sample.Infrastructure.Interface.DomainEventCore;

namespace DDD.Sample.Infrastructure.DomainEventCore
{
    public class Event : IEvent
    {
        /// <summary>
        /// 事件ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 事件触发时间
        /// </summary>
        public DateTime TimeSpan { get; set; }
    }
}
