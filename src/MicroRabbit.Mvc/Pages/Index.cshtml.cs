using MicroRabbit.Web.Model;
using MicroRabbit.Web.Model.DTO;
using MicroRabbit.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MicroRabbit.Web.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly ITransferService _transferService;

		public IndexModel(ILogger<IndexModel> logger, ITransferService transferService)
		{
			_logger = logger;
			_transferService = transferService;
		}

		public void OnGet()
		{

		}

		public async Task OnPost(TransferViewModel transferViewModel)
		{
			var transferDTO = new TransferDTO
			{
				FromAccount = transferViewModel.FromAccount,
				ToAccount = transferViewModel.ToAccount,
				TransferAmount = transferViewModel.TransferAmount
			};

			await _transferService.Transfer(transferDTO);
		}
	}
}
