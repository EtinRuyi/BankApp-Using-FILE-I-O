

//WORKING PERFECLY, USER CAN LOGIN AFTER CLOSE OF CONSOLE, BAL AND NOTE WORKING BUT NOT ARRANGED
using System.Text.Json;
using BankApp.Model.Entities;

namespace BankApp.Data
{
    public class DataStore
    {
        private static string dataFilePath = "BankAppDatabase.json";
        private static List<User> registeredUsers = new List<User>();

        public static async Task InitializeAsync()
        {
            if (File.Exists(dataFilePath))
            {
                await LoadDataAsync();
            }
        }

        public static async Task AddUserAsync(User user)
        {
            registeredUsers.Add(user);
            await SaveDataAsync();
        }

        public static async Task<User> GetUserByEmailAsync(string email)
        {
            return registeredUsers.Find(user => user.Email == email);
        }

        public static List<Account> AllAccounts { get; set; } = new List<Account>();

        public static async Task CreateAccountAsync(Account account)
        {
            AllAccounts.Add(account);
            await SaveDataAsync();
        }

        public static async Task DepositAsync(Account account, decimal amount)
        {
            account.Balance += amount;
            await SaveDataAsync();
        }

        public static async Task WithdrawAsync(Account account, decimal amount)
        {
            account.Balance -= amount;
            await SaveDataAsync();
        }

        public static async Task TransferAsync(Account sourceAccount, Account recipientAccount, decimal amount)
        {
            sourceAccount.Balance -= amount;
            recipientAccount.Balance += amount;
            await SaveDataAsync();
        }

        private static async Task LoadDataAsync()
        {
            try
            {
                using (FileStream fs = File.OpenRead(dataFilePath))
                {
                    var data = await JsonSerializer.DeserializeAsync<DataModel>(fs);
                    registeredUsers = data.RegisteredUsers;
                    AllAccounts = data.AllAccounts;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }
        }

        public static async Task SaveDataAsync()
        {
            try
            {
                var data = new DataModel
                {
                    RegisteredUsers = registeredUsers,
                    AllAccounts = AllAccounts
                };

                using (FileStream fs = File.Create(dataFilePath))
                {
                    await JsonSerializer.SerializeAsync(fs, data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        private class DataModel
        {
            public List<User> RegisteredUsers { get; set; }
            //public List<Account> AllAccounts { get; set; }

            public List<Account> AllAccounts { get; set; } = new List<Account>();
            public List<string> AllAccountTypes
            {
                get
                {
                    return AllAccounts.Select(acc => acc.AccountType.ToString()).ToList();
                }
            }
        }
    }
}





//using System.Text.Json;
//using System.Text.Json.Serialization;
//using BankApp.Model.Entities;

//namespace BankApp.Data
//{
//    public class DataStore
//    {
//        private static string dataFilePath = "BankAppDatabase.json";
//        private static List<User> registeredUsers = new List<User>();

//        public static async Task InitializeAsync()
//        {
//            if (File.Exists(dataFilePath))
//            {
//                await LoadDataAsync();
//            }
//        }

//        public static async Task AddUserAsync(User user)
//        {
//            await LoadDataAsync();
//            registeredUsers.Add(user);
//            await SaveDataAsync();
//        }

//        public static async Task<User> GetUserByEmailAsync(string email)
//        {
//            return registeredUsers.Find(user => user.Email == email);
//        }

//        public static List<Account> AllAccounts { get; set; } = new List<Account>();

//        public static async Task CreateAccountAsync(Account account)
//        {
//            AllAccounts.Add(account);
//            await SaveDataAsync();
//        }

//        public static async Task DepositAsync(Account account, decimal amount)
//        {
//            account.Balance += amount;
//            await SaveDataAsync();
//        }

//        public static async Task WithdrawAsync(Account account, decimal amount)
//        {
//            account.Balance -= amount;
//            await SaveDataAsync();
//        }

//        public static async Task TransferAsync(Account sourceAccount, Account recipientAccount, decimal amount)
//        {
//            sourceAccount.Balance -= amount;
//            recipientAccount.Balance += amount;
//            await SaveDataAsync();
//        }

//        private static async Task LoadDataAsync()
//        {
//            try
//            {
//                using (FileStream fs = File.OpenRead(dataFilePath))
//                {
//                    var data = await JsonSerializer.DeserializeAsync<DataModel>(fs);
//                    registeredUsers = data.RegisteredUsers;
//                    AllAccounts = data.AllAccounts;
//                }
//            }
//            catch (FileNotFoundException)
//            {
//                Console.WriteLine("File not found.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error reading from file: {ex.Message}");
//            }
//        }


//        public static async Task SaveDataAsync()
//        {
//            try
//            {
//                var data = new DataModel
//                {
//                    RegisteredUsers = registeredUsers,
//                    AllAccounts = AllAccounts
//                };

//                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
//                {
//                    Converters = { new JsonStringEnumConverter() }
//                });


//                var formattedJson = FormatJson(json);

//                using (FileStream fs = File.Create(dataFilePath))
//                using (StreamWriter sw = new StreamWriter(fs))
//                {
//                    await sw.WriteAsync(formattedJson);
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error writing to file: {ex.Message}");
//            }
//        }

//        private static string FormatJson(string json)
//        {
//            using (var doc = JsonDocument.Parse(json))
//            {
//                var options = new JsonSerializerOptions
//                {
//                    WriteIndented = true,
//                    Converters = { new JsonStringEnumConverter() }
//                };
//                return JsonSerializer.Serialize(JsonDocument.Parse(json).RootElement, options);
//            }
//        }

//        private class DataModel
//        {
//            public List<User> RegisteredUsers { get; set; }
//            public List<Account> AllAccounts { get; set; }

//            public List<Account> AllAccounts { get; set; } = new List<Account>();
//            public List<string> AllAccountTypes
//            {
//                get
//                {
//                    return AllAccounts.Select(acc => acc.AccountType.ToString()).ToList();
//                }
//            }
//        }
//    }
//}





