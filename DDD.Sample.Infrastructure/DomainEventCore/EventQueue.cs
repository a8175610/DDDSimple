using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Sample.Infrastructure.Interface.DomainEventCore;

namespace DDD.Sample.Infrastructure.DomainEventCore
{
    /// <summary>
    /// 事件处理队列
    /// </summary>
    public class EventQueue
    {
        public event System.EventHandler<IEvent> EventPublished;

        /// <summary>
        /// 推送事件到队列中处理
        /// </summary>
        /// <param name="event"></param>
        public void Push(IEvent @event) => OnMessagePushed(@event);
        
        private void OnMessagePushed(IEvent @event) => EventPublished?.Invoke(this, @event);
    }
}
