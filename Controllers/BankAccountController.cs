using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basic_Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        public readonly EmployeeDbContextClass _dbContext;
        public BankAccountController(EmployeeDbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllBankAccounts")]
        public List<BankAccount> GetAllBankAccounts()
        {
            var bankAccounts = _dbContext.BankAccounts.ToList();
            return bankAccounts;
        }

        [HttpPost("AddBankAccount")]
        public BankAccount AddBankAccount(BankAccount bankAccount)
        {
            _dbContext.BankAccounts.Add(bankAccount);
            _dbContext.SaveChanges();
            return bankAccount;
        }

        [HttpPut("UpdateBankAccount")]
        public BankAccount UpdateBankAccount(BankAccount bankAccount)
        {
            _dbContext.BankAccounts.Update(bankAccount);
            _dbContext.SaveChanges();
            return bankAccount;
        }

        [HttpDelete("DeleteBankAccount/{accountId}")]
        public string DeleteBankAccount(int accountId)
        {
            var bankAccount = _dbContext.BankAccounts.Find(accountId);
            if (bankAccount != null)
            {
                _dbContext.BankAccounts.Remove(bankAccount);
                _dbContext.SaveChanges();
                return $"Bank account with ID {accountId} has been deleted.";
            }
            else
            {
                return $"Bank account with ID {accountId} not found.";
            }
        }

        [HttpGet("GetBankAccountById/{accountId}")]
        public BankAccount GetBankAccountById(int accountId)
        {
            var bankAccount = _dbContext.BankAccounts.Find(accountId);
            return bankAccount ?? throw new ArgumentNullException(nameof(bankAccount));
        }
    }
}
