using BlankStore.Core.Messages;

namespace BlankStore.Core.Bus;

public interface IMediatrHandler
{
    Task PublicarEvento<T>(T evento) where T : Event;
}
