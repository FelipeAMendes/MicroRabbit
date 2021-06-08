using MicroRabbit.Domain.Core.Events;
using System.Threading.Tasks;

namespace MicroRabbit.Domain.Core.Bus
{
	public interface IEventHandler { }

	public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
	{
		Task Handle(TEvent @event);
	}
}
