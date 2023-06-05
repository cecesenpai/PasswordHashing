using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Hash;


namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Create a username : ");
            var userName = Console.ReadLine();

            Console.Write("Create a password :");
            var password = Console.ReadLine();

            SetUserNameAndPassword(userName, password);

            Console.Write("Enter your username :");
            var checkUsername = Console.ReadLine();

            Console.Write("Enter your password :");
            var checkPassword = Console.ReadLine();

            var isAuth = checkUser(checkUsername, checkPassword);

            Console.WriteLine("State :"+isAuth);

            if (isAuth)
            {
                Console.WriteLine("Your Hashed Password : "+InMem.Password);
            }

            Console.ReadLine();

            string CreateHashedText(string _plainText)
            {
                var md5 = new MD5CryptoServiceProvider();
                byte[] plainTextArray = Encoding.UTF8.GetBytes(_plainText);
                plainTextArray = md5.ComputeHash(plainTextArray);
                StringBuilder sb = new StringBuilder();

                foreach (byte ba in plainTextArray)
                {
                    sb.Append(ba.ToString("x2").ToLower());
                }

                return sb.ToString();
            }

            void SetUserNameAndPassword(string _userName, string _password)
            {
                InMem.UserName = _userName;
                InMem.Password = CreateHashedText(_password);
            }

            bool checkUser(string _userName, string _password)
            {
                if (InMem.UserName != _userName)
                {
                    return false;
                }

                if (InMem.Password != CreateHashedText(_password))
                {
                    return false;
                }

                return true;
            }
        }
    }
}
