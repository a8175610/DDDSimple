using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DDD.Sample.Domain.Event.DomainEvents;
using DDD.Sample.Infrastructure.Interface.DomainEventCore;

namespace DDD.Sample.Domain.Event.DomainEventHandlers
{
    public class StudentAddedEventHandler : IEventHandler<StudentAddedEvent>
    {
        public bool CanHandle(IEvent @event)
        {
            return @event.GetType() == typeof(StudentAddedEvent);
        }
        public Task<bool> HandlerAsync(StudentAddedEvent @event, CancellationToken cancellationToken = default)
        {
            //添加学生后的一些后续操作
            //...
            return Task.FromResult(true);
        }

        public Task<bool> HandlerAsync(IEvent @event, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }
    }
}
