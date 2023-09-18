using System.Text.RegularExpressions;

namespace BankApp.Commons.Validations
{
    public class ValidationHelper
    {
        public static string GetValidFirstName()
        {
            string firstName = "";
            while (true)
            {
                Console.Write("Enter first name: ");
                firstName = Console.ReadLine();
                if (IsValidName(firstName))
                {
                    return firstName;
                }
                Console.WriteLine("Invalid name format. First name must start with a capital letter.");
            }
        }

        public static string GetValidLastName()
        {
            string lastName = "";
            while (true)
            {
                Console.Write("Enter last name: ");
                lastName = Console.ReadLine();
                if (IsValidName(lastName))
                {
                    return lastName;
                }
                Console.WriteLine("Invalid name format. Last name must start with a capital letter.");
            }
        }

        public static bool IsValidName(string name) => !string.IsNullOrWhiteSpace(name) && char.IsUpper(name[0]) && name.All(char.IsLetter);

        public static string GetValidEmail()
        {
            string email = "";
            while (true)
            {
                Console.Write("Enter email address: ");
                email = Console.ReadLine().ToLower();
                if (IsValidEmail(email))
                {
                    return email;
                }
                Console.WriteLine("Invalid email format. Please re-enter.");
            }
        }

        public static string GetValidPassword()
        {
            string password = "";
            while (true)
            {
                Console.Write("Enter password: ");
                password = Console.ReadLine();
                if (IsValidPassword(password))
                {
                    return password;
                }
                Console.WriteLine("Invalid password format! Password should be minimum 6 alphanumeric, " +
                    "at least one special character (@, #, $, %, ^, &, !)");
            }
        }

        private static readonly string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            return Regex.IsMatch(email, EmailPattern);
        }

        public static bool IsValidPassword(string password) => Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@#$%^&!]).{6,}$");

    }
}
