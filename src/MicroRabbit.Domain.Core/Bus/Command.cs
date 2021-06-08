using MicroRabbit.Domain.Core.Events;
using System;

namespace MicroRabbit.Domain.Core.Bus
{
	public abstract class Command : Message
	{
		public DateTime Timestamp { get; protected set; }

		protected Command()
		{
			Timestamp = DateTime.Now;
		}
	}
}
