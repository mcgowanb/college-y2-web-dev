using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace DatingSite.app_code
{
    public class CustomValidator : RequestFieldValidatorBase
    {

        public CustomValidator(String error) : base(error)
        {

        }
        protected override bool IsValid(HttpContextBase httpContext, string value)
        {
            return CalculateCheckSum(value); //some sort of validator
        }

        public bool CalculateCheckSum(string value)
        {
            Dictionary<int, String> keyMap = GenerateKeyMap();
            String number = value.Substring(0, value.Length - 1);
            String actualCharacter = value.Substring(value.Length - 1);

            int counter = 8;
            int total = 0;
            foreach (var n in number)
            {
                total += (int)Char.GetNumericValue(n) * counter--;
            }
            int letterNumber = total % 23;
            String finalCharacter = keyMap[letterNumber];
            return finalCharacter.Equals(actualCharacter);
        }

        public Dictionary<int, String> GenerateKeyMap()
        {
            Dictionary<int, String> tmp = new Dictionary<int, string>();
            tmp.Add(1, "A");
            tmp.Add(2, "B");
            tmp.Add(3, "C");
            tmp.Add(4, "D");
            tmp.Add(5, "E");
            tmp.Add(6, "F");
            tmp.Add(7, "G");
            tmp.Add(8, "H");
            tmp.Add(9, "I");
            tmp.Add(10, "J");
            tmp.Add(11, "K");
            tmp.Add(12, "L");
            tmp.Add(13, "M");
            tmp.Add(14, "N");
            tmp.Add(15, "O");
            tmp.Add(16, "P");
            tmp.Add(17, "Q");
            tmp.Add(18, "R");
            tmp.Add(19, "S");
            tmp.Add(20, "T");
            tmp.Add(21, "U");
            tmp.Add(22, "V");
            tmp.Add(23, "W");
            return tmp;
        }
    }

    public class MyValidator
    {
        public static IValidator CheckSum(String errorMessage = null)
        {
            if (String.IsNullOrEmpty(errorMessage))
            {
                errorMessage = "Invalid PPSN Entered, Please try again";
            }
            return new CustomValidator(errorMessage);
        }
    }
}