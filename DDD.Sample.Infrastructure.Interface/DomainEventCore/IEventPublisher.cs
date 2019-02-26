using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Sample.Infrastructure.Interface.DomainEventCore
{
    /// <summary>
    /// 提供事件发布机制
    /// </summary>
    public interface IEventPublisher : IDisposable
    {
        /// <summary>
        /// 发布事件（异步）
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件源</param>
        /// <param name="cancellationToken">支持取消操作</param>
        /// <returns></returns>
        Task PublishAsync<TEvent>(IEvent @event, CancellationToken cancellationToken = default)
            where TEvent : IEvent;
    }
}
