using DDD.Sample.Domain.Aggregate;

namespace DDD.Sample.Domain.Event.DomainEvents
{
    public class StudentAddedEvent : Infrastructure.DomainEventCore.Event
    {
        public Student Student { get; set; }
    }
}
