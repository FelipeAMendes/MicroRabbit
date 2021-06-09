using MicroRabbit.Web.Model.DTO;
using System.Threading.Tasks;

namespace MicroRabbit.Web.Services
{
	public interface ITransferService
	{
		Task Transfer(TransferDTO transferDTO);
	}
}
