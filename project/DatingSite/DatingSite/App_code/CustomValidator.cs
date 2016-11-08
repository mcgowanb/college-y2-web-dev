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
            return true; //some sort of validator
        }
    }

    public class MyValidator
    {
        public static IValidator Checksum(String errorMessage = null)
        {
            if (String.IsNullOrEmpty(errorMessage))
            {
                errorMessage = "No Value entered, please try again";
            }
            return new CustomValidator(errorMessage);
        }
    }
}