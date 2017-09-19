using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace bankAccounts.Models
{
    public class TransactionViewModel : BaseEntity
    {
        [Display(Name = "Deposit/Withdraw")]
        public int amount { get; set; }
    }
}