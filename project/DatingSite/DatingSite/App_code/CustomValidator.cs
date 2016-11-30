using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using System.Text.RegularExpressions;
using System.Text;

namespace DatingSite.App_code
{
    public class CustomValidator : RequestFieldValidatorBase
    {

        public CustomValidator(String error) : base(error)
        {

        }
        protected override bool IsValid(HttpContextBase httpContext, string value)
        {
            return CalculateCheckSum(value);
        }


        /// <summary>
        /// Checeks the PPSN for string length and characters appended after.
        /// If successful on string length, it also runs through the Mod23 checker
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool CalculateCheckSum(string value)
        {
            String regex = @"^[0-9]{7}[A-Z]{1,2}$";
            Regex r = new Regex(regex, RegexOptions.IgnoreCase);
            Match m = r.Match(value);
            if (m.Success)
            {
                return CheckMOD23(value);
            }
            else return false;
        }

        /// <summary>
        /// Check Mod 23. Checks the Modulus of 23 to ge the remainder for calculating the
        /// letter associated with the PPSN
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool CheckMOD23(String value)
        {
            int length = value.Length;
            int total = 0;
            for (int i = 0; i < 7; ++i)
            {
                total += (int)value[i] * (8 - i);
            }

            byte[] asciiBytes = Encoding.ASCII.GetBytes(value.ToUpper());
            if (length == 9)
            {
                total += ((int)asciiBytes[8] - 64) * 9;
            }

            int mod = total % 23;
            if (mod == 0) mod = 23;

            int nV = 63 + mod;
            int cV = asciiBytes[7];
            return nV == cV;
        }
    }

    public class MyValidator
    {

        /// <summary>
        /// Custom implementation of validator for PPSN checksum, uses the new CustomValidator Object
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
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