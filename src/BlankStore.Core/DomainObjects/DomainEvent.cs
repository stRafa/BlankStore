using BlankStore.Core.Messages;

namespace BlankStore.Core.DomainObjects;

public class DomainEvent : Event
{
    public DomainEvent(Guid aggregateId) 
    {
        AggregateId = aggregateId;
    }
}
