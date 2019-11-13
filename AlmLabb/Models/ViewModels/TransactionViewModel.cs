using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlmLabb.Models.ViewModels
{
    public class TransactionViewModel
    {
        [Required]
        public string TransactionType { get; set; }
        [Required]
        public int AccountID { get; set; }
        [Range(0.001, (double)decimal.MaxValue)]
        public decimal Amount { get; set; }

        public TransactionResult Result { get; set; } 

    }

    public class TransactionResult
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }

        public TransactionResult()
        {

        }
        public TransactionResult(bool success, string message)
        {
            IsSuccessful = success;
            Message = message;
        }
    }
}
