namespace MicroRabbit.Banking.Application.ViewModels
{
    public class AccountTransfer
    {
        public int AccountSource { get; set; }
        public int AccountDest { get; set; }
        public decimal TransferAmount { get; set; }
    }
}
