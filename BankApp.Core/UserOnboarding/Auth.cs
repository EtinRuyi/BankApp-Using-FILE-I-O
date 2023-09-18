using BankApp.Commons.Validations;
using BankApp.Data;
using BankApp.Model.Entities;


namespace BankApp.Core.UserOnboarding
{
    public class Auth
    {
        public async Task RegisterMeAsync()
        {
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Password = "";

            Console.Clear();
            Console.WriteLine("REGISTRATION PORTAL \n");
            Console.WriteLine("Please fill in your details...");
            FirstName = ValidationHelper.GetValidFirstName();

            Console.Clear();
            Console.WriteLine("REGISTRATION PORTAL \n");
            Console.WriteLine("Please fill in your details...");
            LastName = ValidationHelper.GetValidLastName();

            Console.Clear();
            Console.WriteLine("REGISTRATION PORTAL \n");
            Console.WriteLine("Please fill in your details...");
            Email = ValidationHelper.GetValidEmail();

            Console.Clear();
            Console.WriteLine("REGISTRATION PORTAL \n");
            Console.WriteLine("Please fill in your details...");
            Password = ValidationHelper.GetValidPassword();

            Console.Clear();
            Console.WriteLine("REGISTRATION PORTAL \n");
            var createdUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await DataStore.AddUserAsync(createdUser);
            Console.WriteLine();
            Console.WriteLine("Registration successful!");
            Console.WriteLine("Press Enter to continue...");
        }

        public async Task<User> LoginAsync()
        {
            Console.Clear();
            Console.WriteLine("LOGIN PORTAL");
            Console.WriteLine("IMPORTANT NOTICE: Keep your account information confidential. Your security is our top priority. \n");

            string email = "";
            string password = "";

            Console.WriteLine("Please fill in your correct details...");
            email = ValidationHelper.GetValidEmail();

            Console.Clear();
            Console.WriteLine("LOGIN PORTAL");
            Console.WriteLine("IMPORTANT NOTICE: Keep your account information confidential. Your security is our top priority. \n");
            Console.WriteLine("Please fill in your correct details...");
            password = ValidationHelper.GetValidPassword();

            User userExist = await DataStore.GetUserByEmailAsync(email);

            if (userExist != null && userExist.Password == password)
            {
                // Successful login, set the logged-in user
                Session.LoggedInUser = userExist;
                return userExist;
            }
            else
            {
                Console.WriteLine("Login failed. Invalid email or password.");
                Console.ReadKey();
                return null;
            }
        }


        public void LogOut()
        {
            Console.Clear();
            Console.WriteLine("SESSION-OUT \n");
            Session.LoggedInUser = null;
            Console.WriteLine("Logged Out!");
            Console.WriteLine("Press Enter to exit the application...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
