using BankApp.Data;
using BankApp.UI.HomePage;

namespace BankApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await DataStore.InitializeAsync();

            WelcomePage.RunBankController();

            AppDomain.CurrentDomain.ProcessExit += async (sender, eventArgs) =>
            {
                await DataStore.SaveDataAsync();
            };
        }
    }
}