using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    public class BaseSteps(ScenarioContext context)
    {
        protected readonly CreateAccountStepsHelper createAccountStepsHelper = new(context);
        protected readonly ConfirmMyApprenticeshipStepsHelper confirmMyApprenticeshipStepsHelper = new(context);
        protected readonly PasswordResetStepsHelper passwordResetStepsHelper = new(context);
        protected readonly ApprenticeCommitmentsConfig config = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>();
        protected readonly TabHelper tabHelper = context.Get<TabHelper>();
        protected readonly ObjectContext objectContext = context.Get<ObjectContext>();
    }
}
