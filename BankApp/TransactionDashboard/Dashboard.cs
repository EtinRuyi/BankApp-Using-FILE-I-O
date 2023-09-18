using BankApp.Core.Implementations;
using BankApp.Core.UserOnboarding;
using BankApp.Model.Entities;

namespace BankApp.UI.TransactionDashboard
{
    public class Dashboard
    {
        public async Task DisplayMenuAsync(User loggedInUser)
        {
            var transact = new Transactions();
            var auth = new Auth();
            bool logout = false;

            while (!logout)
            {
                Console.Clear();
                Console.WriteLine("DASHBOARD");
                Console.Write($"Greetings, {loggedInUser.FullName}! Your account is securely logged in...\n\n");
                Console.WriteLine("Please select the option that suits your needs.");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Check Balance");
                Console.WriteLine("6. Print Statement of Account");
                Console.WriteLine("7. Log Out");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {

                    switch (choice)
                    {
                        case 1:
                            await transact.CreateAccountAsync(loggedInUser);
                            await DisplayMenuAsync(loggedInUser);
                            break;
                        case 2:
                            await transact.DepositAsync(loggedInUser);
                            break;
                        case 3:
                            await transact.WithdrawAsync(loggedInUser);
                            break;
                        case 4:
                            await transact.TransferAsync(loggedInUser);
                            break;
                        case 5:
                            transact.GetBalance(loggedInUser);
                            break;
                        case 6:
                            transact.PrintStatementOfAccount(loggedInUser);
                            break;
                        case 7:
                            auth.LogOut();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                Console.ReadKey();
            }
        }
    }
}
