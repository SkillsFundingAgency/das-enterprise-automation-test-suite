using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers
{
    public class SetApprenticeDetailsHelper(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        public (string firstName, string lastName) SetApprenticeDetails(ApprenticeUser user)
        {
            (string firstName, string lastName) = SetApprenticeDetailsInObjectContext(user);

            context.Get<ApprenticeDataHelper>().UpdateCurrentApprenticeName(firstName, lastName);

            return (firstName, lastName);
        }

        public (string firstName, string lastName) SetApprenticeDetailsInObjectContext(ApprenticeUser user)
        {
            (string apprenticeId, string firstName, string lastName, string username) = (user.Id, user.FirstName, user.LastName, user.Username);

            _objectContext.SetApprenticeId(apprenticeId);
            _objectContext.SetApprenticeEmail(username);
            _objectContext.SetApprenticePassword(user.IdOrUserRef);

            _objectContext.SetFirstName(firstName);
            _objectContext.SetLastName(lastName);

            return (firstName, lastName);
        }
    }
}