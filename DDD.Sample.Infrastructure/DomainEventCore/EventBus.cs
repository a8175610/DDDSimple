using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DDD.Sample.Infrastructure.Interface.DomainEventCore;

namespace DDD.Sample.Infrastructure.DomainEventCore
{
    /// <summary>
    /// 事件总线实现类
    /// 此处提供简单的事件总线实现
    /// 消息发送、接收方式为即发即废，并未实现事件存储、事件持久化、消息回执等功能
    /// 如果需要实现以上功能，可以考虑使用RabbitMQ等消息机制
    /// </summary>
    public class EventBus : IEventBus
    {
        private readonly EventQueue _eventQueue;
        private readonly IEnumerable<IEventHandler> _eventHandlers;
        public EventBus()
        {
            _eventQueue = new EventQueue();
            this._eventHandlers = GetEventHandlers();
        }

        /// <summary>
        /// 加载所有事件处理器
        /// </summary>
        /// <returns></returns>
        private IEnumerable<IEventHandler> GetEventHandlers()
        {
            var resultList = new List<IEventHandler>();
            var assembly = Assembly.Load("DDD.Sample.Domain.Event");
            //加载所有继承IEventHandler接口的非泛型类
            var eventHandlerTypes = assembly.GetTypes().Where(
                r => !r.IsGenericType && r.GetInterface(typeof(IEventHandler).Name) != null);
            foreach (var eventHandlerType in eventHandlerTypes)
            {
                var eventHandler = (IEventHandler)Activator.CreateInstance(eventHandlerType);
                resultList.Add(eventHandler);
            }
            return resultList;
        }

        private void EventQueue_EventPublished(object obj, IEvent e)
        {
            _eventHandlers.Where(r => r.CanHandle(e))
                .ToList()
                .ForEach(async r => await r.HandlerAsync(e));
        }

        public Task PublishAsync<TEvent>(IEvent @event, CancellationToken cancellationToken = default(CancellationToken)) where TEvent : IEvent
        {
            return Task.Run(() => _eventQueue.Push(@event));
        }

        public void Subscrib()
        {
            _eventQueue.EventPublished += EventQueue_EventPublished;
        }

        #region Dispose...
        private bool disposeValue = false;
        void Dispose(bool disposing)
        {
            if (!disposeValue)
            {
                if (disposing)
                {
                    _eventQueue.EventPublished -= EventQueue_EventPublished;
                }
                disposeValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
