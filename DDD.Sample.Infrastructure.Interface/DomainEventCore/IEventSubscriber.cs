using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sample.Infrastructure.Interface.DomainEventCore
{
    /// <summary>
    /// 提供事件订阅机制
    /// </summary>
    public interface IEventSubscriber : IDisposable
    {
        /// <summary>
        /// 订阅事件
        /// </summary>
        void Subscrib();
    }
}
