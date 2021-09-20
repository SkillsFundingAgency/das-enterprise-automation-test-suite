using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers
{
    public class BaseStepsHelper
    {
        readonly CreateAccountStepsHelper createAccountStepsHelper;
        readonly ConfirmMyApprenticeshipStepsHelper confirmMyApprenticeshipStepsHelper;
        readonly PasswordResetStepsHelper passwordResetStepsHelper;
        protected readonly TabHelper tabHelper;

        public BaseStepsHelper(ScenarioContext context)
        {
            createAccountStepsHelper = new CreateAccountStepsHelper(context);
            confirmMyApprenticeshipStepsHelper = new ConfirmMyApprenticeshipStepsHelper(context);
            passwordResetStepsHelper = new PasswordResetStepsHelper(context);
            tabHelper = context.Get<TabHelper>();
        }
    }
}
