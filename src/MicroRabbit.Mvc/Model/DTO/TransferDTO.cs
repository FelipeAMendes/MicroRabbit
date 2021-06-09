namespace MicroRabbit.Web.Model.DTO
{
	public class TransferDTO
	{
		public int FromAccount { get; set; }
		public int ToAccount { get; set; }
		public decimal TransferAmount { get; set; }
	}
}
