using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingSite.App_code
{
    public class User
    {

        /// <summary>
        /// User Class to contain all user related information
        /// </summary>
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String DateOfBirth { get; set; }
        public String PPSN { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Height { get; set; }
        public String Password { get; set; }
        public String ConfirmPassword { get; set; }
        public String Gender { get; set; }
        public String Relationship { get; set; }
        public String SportingInterests { get; set; }
        public String CulturalInterests { get; set; }

    }
}