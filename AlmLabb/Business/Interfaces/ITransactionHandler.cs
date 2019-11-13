using AlmLabb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmLabb.Business.Interfaces
{
    public interface ITransactionHandler
    {
        TransactionResult Handle(TransactionViewModel transaction);
    }
}
