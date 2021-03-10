using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class ApprenticeCommitmentsBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly ApprenticeLoginSqlDbHelper loginInvitationsSqlDbHelper;
        protected readonly ObjectContext objectContext;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly ApprenticeCommitmentsConfig apprenticeCommitmentsConfig;
        protected readonly ApprenticeCommitmentsDataHelper apprenticeCommitmentsDataHelper;
        #endregion

        public ApprenticeCommitmentsBasePage(ScenarioContext context) : base(context)
        {
            objectContext = context.Get<ObjectContext>();

            pageInteractionHelper = context.Get<PageInteractionHelper>();

            formCompletionHelper = context.Get<FormCompletionHelper>();

            loginInvitationsSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();

            apprenticeCommitmentsConfig = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>();

            apprenticeCommitmentsDataHelper = context.Get<ApprenticeCommitmentsDataHelper>();
        }
    }
}
