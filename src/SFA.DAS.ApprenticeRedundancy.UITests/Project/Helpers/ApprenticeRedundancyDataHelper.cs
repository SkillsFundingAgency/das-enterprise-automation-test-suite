using MongoDB.Bson.Serialization.IdGenerators;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers
{
    public class ApprenticeRedundancyDataHelper : RandomElementHelper
    {
        public ApprenticeRedundancyDataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator)
        {
            ContactNumber = randomDataGenerator.GenerateRandomNumber(8);
            Months = randomDataGenerator.GenerateRandomNumberBetweenTwoValues(0,11);
        }

        public DateTime Dob(int x) => DateTime.Now.AddYears(-40 + x);
        public string FullName => "Apprentice Smith";
        public string JobRole => "Employee";
        public string Email => "test.demo@digital.education.gov.uk";
        public string Postcode => "CV22 4NX";
        public string Day => "10";
        public string Month => "11";
        public string Year => "2000";
        public string PreviousApprenticeshipTraining = "Information Technology";
        public string Location = "Coventry";
        public string Employer = "Apprentice Digital Education";
        public string TrainingProvider = "TEST Regression";
        public int Months { get; }
        public string ContactNumber { get; }

    }
}

