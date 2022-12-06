using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers
{
    public class SetApprenticeDetailsHelper
    {
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        private readonly ApprenticeCommitmentsAccountsSqlDbHelper _appAccSqlDbHelper;

        public SetApprenticeDetailsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _appAccSqlDbHelper = context.Get<ApprenticeCommitmentsAccountsSqlDbHelper>();
        }

        public (string firstName, string lastName) SetApprenticeDetails(ApprenticeUser user)
        {
            (string firstName, string lastName) = SetApprenticeDetailsInObjectContext(user);

            _context.Get<ApprenticeDataHelper>().UpdateCurrentApprenticeName(firstName, lastName);

            return (firstName, lastName);
        }

        public (string firstName, string lastName) SetApprenticeDetailsInObjectContext(ApprenticeUser user)
        {
            var username = user.ApprenticeUsername;

            (string apprenticeId, string firstName, string lastName) = _appAccSqlDbHelper.GetApprenticeDetails(username);

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                Assert.Fail($"{username} not found in the db");

            _objectContext.SetApprenticeId(apprenticeId);
            _objectContext.SetApprenticeEmail(username);
            _objectContext.SetApprenticePassword(user.ApprenticePassword);

            _objectContext.SetFirstName(firstName);
            _objectContext.SetLastName(lastName);

            return (firstName, lastName);
        }
    }
}