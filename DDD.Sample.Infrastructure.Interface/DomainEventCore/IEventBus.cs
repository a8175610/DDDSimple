using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sample.Infrastructure.Interface.DomainEventCore
{
    /// <summary>
    /// 事件总线，提供订阅、发布事件
    /// </summary>
    public interface IEventBus : IEventPublisher, IEventSubscriber
    {

    }
}
