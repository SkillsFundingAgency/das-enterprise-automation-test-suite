using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class ApprenticeDataHelper
    {
        private readonly CommitmentsSqlDataHelper _commitmentsdataHelper;

        private readonly ObjectContext _objectContext;

        public readonly ApprenticePPIDataHelper apprenticePPIDataHelper;

        public ApprenticeDataHelper(ApprenticePPIDataHelper apprenticePPIDataHelper, ObjectContext objectContext, CommitmentsSqlDataHelper commitmentsdataHelper)
            : this(apprenticePPIDataHelper, objectContext, commitmentsdataHelper, string.Empty) { }

        public ApprenticeDataHelper(ApprenticePPIDataHelper apprenticePPIDataHelper, ObjectContext objectContext, CommitmentsSqlDataHelper commitmentsdataHelper, string trainingCost)
        {
            _objectContext = objectContext;
            this.apprenticePPIDataHelper = apprenticePPIDataHelper;
            _commitmentsdataHelper = commitmentsdataHelper;
            ApprenticeFirstname = apprenticePPIDataHelper.ApprenticeFirstname;
            ApprenticeLastname = apprenticePPIDataHelper.ApprenticeLastname;
            DateOfBirthDay = apprenticePPIDataHelper.DateOfBirthDay;
            DateOfBirthMonth = apprenticePPIDataHelper.DateOfBirthMonth;
            DateOfBirthYear = apprenticePPIDataHelper.DateOfBirthYear;
            TrainingCost = trainingCost == string.Empty ? "1" + RandomDataGenerator.GenerateRandomNumber(3) : trainingCost;
            EmployerReference = RandomDataGenerator.GenerateRandomAlphanumericString(10);
            ApprenticeULN = RandomDataGenerator.GenerateRandomUln();
            _apprenticeid = 0;
        }

        public string ApprenticeULN { get; set; }

        public string ApprenticeFirstname { get; set; }

        public string ApprenticeLastname { get; set; }

        public string ApprenticeFullName => $"{ApprenticeFirstname} {ApprenticeLastname}";

        public string ApprenticeEmail => apprenticePPIDataHelper.ApprenticeEmail;

        public int DateOfBirthDay { get; set; }

        public int DateOfBirthMonth { get; set; }

        public int DateOfBirthYear { get; set; }

        public DateTime ApprenticeDob => new(DateOfBirthYear, DateOfBirthMonth, DateOfBirthDay);

        public string TrainingCost { get; set; }

        public string EmployerReference { get; }

        public string MadeRedundant { get; set; }

        public string MessageToProvider => $"Apprentice {ApprenticeFullName}, Total Cost {_objectContext.GetApprenticeTotalCost()}";

        public string MessageToEmployer => $"Added {ApprenticeULN} uln, {MessageToProvider}";

        public int ApprenticeshipId(string title) => _apprenticeid == 0 ? GetApprenticeshipIdForCurrentLearner(title) : _apprenticeid;

        private int _apprenticeid;

        private int GetApprenticeshipIdForCurrentLearner(string title)
        {
            _apprenticeid = _commitmentsdataHelper.GetApprenticeshipId(ApprenticeULN, title);
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
