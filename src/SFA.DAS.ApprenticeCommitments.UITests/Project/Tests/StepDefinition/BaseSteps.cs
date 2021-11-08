using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    public class BaseSteps
    {
        protected readonly CreateAccountStepsHelper createAccountStepsHelper;
        protected readonly ConfirmMyApprenticeshipStepsHelper confirmMyApprenticeshipStepsHelper;
        protected readonly PasswordResetStepsHelper passwordResetStepsHelper;
        protected readonly ApprenticeCommitmentsConfig config;
        protected readonly TabHelper tabHelper;
        protected readonly ObjectContext objectContext;

        public BaseSteps(ScenarioContext context)
        {
            createAccountStepsHelper = new CreateAccountStepsHelper(context);
            confirmMyApprenticeshipStepsHelper = new ConfirmMyApprenticeshipStepsHelper(context);
            passwordResetStepsHelper = new PasswordResetStepsHelper(context);
            config = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>();
            tabHelper = context.Get<TabHelper>();
            objectContext = context.Get<ObjectContext>();
        }
    }
}
