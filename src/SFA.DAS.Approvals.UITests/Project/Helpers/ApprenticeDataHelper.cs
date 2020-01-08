using System.Collections.Generic;
using System.Linq;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class ApprenticeDataHelper 
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly CommitmentsDataHelper _commitmentsdataHelper;
        private readonly ObjectContext _objectContext;

        public ApprenticeDataHelper(ObjectContext objectContext, RandomDataGenerator randomDataGenerator, CommitmentsDataHelper commitmentsdataHelper)
        {
            _objectContext = objectContext;
            _randomDataGenerator = randomDataGenerator;
            _commitmentsdataHelper = commitmentsdataHelper;         
            ApprenticeFirstname = $"F_{_randomDataGenerator.GenerateRandomAlphabeticString(10)}";
            ApprenticeLastname = $"L_{_randomDataGenerator.GenerateRandomAlphabeticString(10)}";
            DateOfBirthDay = _randomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = _randomDataGenerator.GenerateRandomMonth();
            DateOfBirthYear = _randomDataGenerator.GenerateRandomDobYear();
            TrainingPrice = "1" + _randomDataGenerator.GenerateRandomNumber(3);
            EmployerReference = _randomDataGenerator.GenerateRandomAlphanumericString(10);
            Ulns = new List<string>();
            _apprenticeid = 0;
        }

        public string ApprenticeFirstname { get; }      

        public string ApprenticeLastname { get; }

        public string ApprenticeFullName => $"{ApprenticeFirstname} {ApprenticeLastname}";

        public int DateOfBirthDay { get; }

        public int DateOfBirthMonth { get; }

        public int DateOfBirthYear { get; }

        public string TrainingPrice { get; }

        public string EmployerReference { get; }

        public string MessageToProvider => $"Apprentice {ApprenticeFullName}, Total Cost {_objectContext.GetApprenticeTotalCost()}";

        public string MessageToEmployer => $"Added {string.Join(",", Ulns)} ulns, {MessageToProvider}";

        public List<string> Ulns { get; private set; }

        public string Uln()
        {
            var uln = _randomDataGenerator.GenerateRandomUln();
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
    }
}
