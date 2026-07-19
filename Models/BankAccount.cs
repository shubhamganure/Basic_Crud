using System;

namespace Basic_Crud
{
    public class BankAccount
    {
        public int accountId { get; set; }
        public string accountNumber { get; set; } = string.Empty;
        public string accountHolderName { get; set; } = string.Empty;
        public string accountType { get; set; } = string.Empty;
        public decimal balance { get; set; }
        public bool isActive { get; set; }
    }
}
