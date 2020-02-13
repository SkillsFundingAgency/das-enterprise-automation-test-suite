using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Helpers
{
    public class RunTimevariable
    {
        public static String _employerFirstName;
        public static String _employerLastName;
        private string _firstNameRandomChar;
        private string _lastNameRandomChar;
        private  RandomDataGenerator randomDataGenerator;
        private readonly CampaignsConfig _configuration;


        public void SetAllValuesToNull()
        {
            _employerFirstName = null;
            _employerLastName = null;


        }
        public  string GetEmployerFirstname(String firstname)
        {
            if (_employerFirstName == null)
            {
              
                randomDataGenerator = new RandomDataGenerator();
                _firstNameRandomChar= randomDataGenerator.GenerateRandomAlphabeticString(4);
                _employerFirstName = (firstname + _firstNameRandomChar).ToUpper();
             }
            return _employerFirstName;
        }


        public string GetEmployerLastname(String lastname)
        {
            if (_employerLastName == null)
            {
                _employerLastName = lastname;
                _lastNameRandomChar = randomDataGenerator.GenerateRandomAlphabeticString(4);
                _employerLastName = (lastname + _lastNameRandomChar).ToUpper();
              }
            return _employerLastName;

        }
    }
}
