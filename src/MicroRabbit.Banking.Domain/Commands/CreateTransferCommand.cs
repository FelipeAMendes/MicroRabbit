using MediatR;

namespace MicroRabbit.Banking.Domain.Commands
{
	public class CreateTransferCommand : TransferCommand, IRequest<bool>
	{
		public CreateTransferCommand(int from, int to, decimal amount)
		{
			From = from;
			To = to;
			Amount = amount;
		}
	}
}
