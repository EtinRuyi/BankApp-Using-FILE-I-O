using BankApp.Model.Enums;

namespace BankApp.Model.Entities
{
    public class Account : BaseEntity
    {
        public int AccountNo { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Balance { get; set; }
        public Guid UserId { get; set; }
        public string Note { get; set; }
    }
}
