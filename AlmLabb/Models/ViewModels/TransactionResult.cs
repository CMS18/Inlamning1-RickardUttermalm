using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmLabb.Models.ViewModels
{
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
