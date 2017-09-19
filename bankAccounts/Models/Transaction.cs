using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace bankAccounts.Models
{
    public class Transaction : BaseEntity
    {
        public long id { get; set; }
        public int amount { get; set; }
        public DateTime date { get; set; }

    }
}