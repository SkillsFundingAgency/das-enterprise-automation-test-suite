using System;
using System.Collections.Generic;
using System.Linq;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class ApprenticeDataHelper : RandomElementHelper
    {
        private readonly CommitmentsSqlDataHelper _commitmentsdataHelper;
        private readonly ObjectContext _objectContext;
        private readonly ApprenticePPIDataHelper _apprenticePPIDataHelper;

        public ApprenticeDataHelper(ApprenticePPIDataHelper apprenticePPIDataHelper, ObjectContext objectContext, RandomDataGenerator randomDataGenerator, CommitmentsSqlDataHelper commitmentsdataHelper) : base(randomDataGenerator)
        {
            _objectContext = objectContext;
            _apprenticePPIDataHelper = apprenticePPIDataHelper;
            _commitmentsdataHelper = commitmentsdataHelper;
            ApprenticeFirstname = apprenticePPIDataHelper.ApprenticeFirstname;
            ApprenticeLastname = apprenticePPIDataHelper.ApprenticeLastname;
            DateOfBirthDay = apprenticePPIDataHelper.DateOfBirthDay;
            DateOfBirthMonth = apprenticePPIDataHelper.DateOfBirthMonth;
            DateOfBirthYear = apprenticePPIDataHelper.DateOfBirthYear;
            TrainingPrice = "1" + randomDataGenerator.GenerateRandomNumber(3);
            EmployerReference = randomDataGenerator.GenerateRandomAlphanumericString(10);
            Ulns = new List<string>();
            _apprenticeid = 0;
        }

        public string ApprenticeFirstname { get; set; }

        public string ApprenticeLastname { get; set; }

        public string ApprenticeFullName => $"{ApprenticeFirstname} {ApprenticeLastname}";

        public string ApprenticeEmail => _apprenticePPIDataHelper.ApprenticeEmail;

        public int DateOfBirthDay { get; set; }

        public int DateOfBirthMonth { get; set; }

        public int DateOfBirthYear { get; set; }

        public DateTime ApprenticeDob => new DateTime(DateOfBirthYear, DateOfBirthMonth, DateOfBirthDay);

        public string TrainingPrice { get; set; }

        public string EmployerReference { get; }

        public string MadeRedundant { get; set; }

        public string MessageToProvider => $"Apprentice {ApprenticeFullName}, Total Cost {_objectContext.GetApprenticeTotalCost()}";

        public string MessageToEmployer => $"Added {Ulns.ToString(",")} ulns, {MessageToProvider}";

        public List<string> Ulns { get; private set; }

        public string Uln()
        {
            var uln = randomDataGenerator.GenerateRandomUln();
            Ulns.Add(uln);
            return uln;
        }

        public int ApprenticeshipId()
        {
            return _apprenticeid == 0 ? GetApprenticeshipIdForCurrentLearner() : _apprenticeid;
        }

        private int _apprenticeid;

        private int GetApprenticeshipIdForCurrentLearner()
        {
            _apprenticeid = _commitmentsdataHelper.GetApprenticeshipId(Ulns.Single());
            _objectContext.SetApprenticeId(_apprenticeid);
            return _apprenticeid;
        }

        public void UpdateCurrentApprenticeName(string firstName, string lastName)
        {
            ApprenticeFirstname = firstName;
            ApprenticeLastname = lastName;
        }
    }
}
