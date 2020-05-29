using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages
{
    public abstract class ApprovalsBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly TableRowHelper tableRowHelper;
        protected readonly TabHelper tabHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        protected readonly RegistrationConfig registrationConfig;
        protected readonly PublicSectorReportingDataHelper dataHelper;
        #endregion


        protected ApprovalsBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            tableRowHelper = context.Get<TableRowHelper>();
            tabHelper = context.Get<TabHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            registrationConfig = context.GetRegistrationConfig<RegistrationConfig>();
            dataHelper = context.Get<PublicSectorReportingDataHelper>();
            if (verifypage) VerifyPage();
        }
    }
}