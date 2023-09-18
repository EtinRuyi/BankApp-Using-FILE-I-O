using BankApp.Data;
using BankApp.Model.Entities;

namespace BankApp.Commons.TransactHelp
{
    public class TransactionsHelper
    {
        public static int GenerateAccountNumber()
        {

            Random random = new Random();
            var AccountNumber = random.Next(2090000006, 2135574930);
            return AccountNumber;
        }


        public void PrintAllAccounts(User loggedInUser)
        {
            var userAccounts = DataStore.AllAccounts.Where(account => account.UserId == loggedInUser.Id).ToList();

            Console.WriteLine("=============================================================================================================");
            Console.WriteLine("|      FULL NAME       |      ACCOUNT NUMBER      |      ACCOUNT TYPE      |      AMOUNT BAL(#)     |    REMARKS       ");
            Console.WriteLine("=============================================================================================================");

            foreach (Account account in userAccounts)
            {
                Console.WriteLine($"| {loggedInUser.FullName,-21} | {account.AccountNo,-23} | {account.AccountType,-24} | #{account.Balance.ToString("N2"),-21}  | {account.Note,-15} ");
            }

            Console.WriteLine("=============================================================================================================");
            Console.WriteLine("\n Thanks for banking with us...");
        }
    }
}
