using AlmLabb.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlmLabb.Models.ViewModels
{
    public class TransferViewModel
    {
        [Required]
        [Display(Name = "ID of Sending Account")]
        public int FromAccountId { get; set; }

        [Required]
        [Display(Name = "ID of Receiving Account")]
        public int ToAccountId { get; set; }

        [Required]
        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        [Range(0.001, (double)decimal.MaxValue)]
        public decimal Amount { get; set; } = 0;

        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }

        public TransactionResult Result { get; set; }
    }
}
