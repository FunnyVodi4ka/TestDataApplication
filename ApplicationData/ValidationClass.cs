using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace test_demo_exam_04.ApplicationData
{
    class ValidationClass
    {
        public bool CheckStringData(string str, int minLength = 2, int maxLength = 150)
        {
            if(str.Length >= minLength && str.Length <= maxLength)
            {
                return true;
            }
            return false;
        }

        public bool CheckPassword(string password)
        {
            string pattern = @"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*])[0-9a-zA-Z!@#$%^&*]{6,50}";
            Match isMatch = Regex.Match(password, pattern);
            return isMatch.Success;
        }

        public bool CheckEmail(string email)
        {
            if(email.Length >= 5 && email.Length <= 250)
            {
                string pattern = "(^[0-9a-z._-]+@[a-z]+\\.[a-z]+)";
                Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
                return isMatch.Success;
            }
            return false;
        }

        public bool CheckPhone(string phone)
        {
            string pattern = "^8-\\d{3}-\\d{3}-\\d{2}-\\d{2}";
            Match isMatch = Regex.Match(phone, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }

        public bool CheckIntData(string number, int minValue = 0)
        {
            try
            {
                int correctData = Int32.Parse(number);
                if(correctData >= minValue)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckDateOfBirth(string date)
        {
            try
            {
                DateTime correctDate = DateTime.Parse(date);
                if(correctDate != null && correctDate >= DateTime.Now.AddDays(-365*110) && correctDate <= DateTime.Now.AddDays(-365 * 14))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
