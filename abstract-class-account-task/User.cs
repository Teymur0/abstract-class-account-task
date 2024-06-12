

using System.Reflection.Metadata.Ecma335;

namespace abstract_class_account_task
{
    internal class User:Account
    {
        private static int _id = 0;

        public int Id { get;}
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public User(string fullName, string email, string password)
        {

            Id = ++_id;
            Fullname = fullName;
            Email = email;
            Password = password;

        }
        public override void ShowInfo()
        {

            Console.WriteLine($"Fullname: {Fullname} -- Email: {Email} -- ");
        }

        public override bool PasswordChecker(string str)
        {
            bool isUpperLetter=false;
            bool isLowerLetter= false;
            bool isDigit=false;

            if (str.Length < 8)
            {
                return false;
            }

            for (int i = 0;i<str.Length; i++) {
                if (Char.IsUpper(str[i]))
                {
                    isUpperLetter = true;

                } 
                else if (Char.IsLower(str[i]))
                {
                    isLowerLetter= true;

                }
                else if (Char.IsDigit(str[i]))
                {
                    isDigit= true;
                }

                if (isUpperLetter&&isLowerLetter&&isDigit)
                {
                    return true;
                }

              
            
            
            }

            return false;
        }
    }
}
