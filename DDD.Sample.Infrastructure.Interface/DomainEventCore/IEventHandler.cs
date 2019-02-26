using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Sample.Infrastructure.Interface.DomainEventCore
{
    /// <summary>
    /// 事件处理,提供事件处理机制
    /// </summary>
    public interface IEventHandler
    {
        /// <summary>
        /// 检查指定的事件源是否可以被处理
        /// </summary>
        /// <param name="event">事件源</param>
        /// <returns></returns>
        bool CanHandle(IEvent @event);
        /// <summary>
        /// 事件处理方法
        /// </summary>
        /// <param name="event">事件源</param>
        /// <param name="cancellationToken">支持取消操作</param>
        Task<bool> HandlerAsync(IEvent @event, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// 事件处理（泛型）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEventHandler<in T> : IEventHandler
    {
        /// <summary>
        /// 事件处理方法
        /// </summary>
        /// <param name="event">事件源</param>
        /// <param name="cancellationToken">支持取消操作</param>
        /// <returns></returns>
        Task<bool> HandlerAsync(T @event, CancellationToken cancellationToken = default);
    }
}
