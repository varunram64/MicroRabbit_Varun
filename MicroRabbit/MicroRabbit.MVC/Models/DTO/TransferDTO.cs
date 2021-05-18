using System.ComponentModel.DataAnnotations;

namespace MicroRabbit.MVC.Models.DTO
{
    public class TransferDTO
    {
        [Display(Name = "AccountSource")]
        public int FromAccount { get; set; }
        [Display(Name = "AccountDest")]
        public int ToAccount { get; set; }
        [Display(Name = "TransferAmount")]
        public decimal TransferAmount { get; set; }
    }
}
