using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages
{
    public abstract class ApprovalsBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly RegexHelper regexHelper;
        protected readonly LoginCredentialsHelper loginCredentialsHelper;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly TabHelper tabHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        protected readonly RegistrationConfig registrationConfig;
        protected readonly ApprovalsConfig approvalsConfig;
        protected readonly TransfersConfig transfersConfig;
        protected readonly ProviderConfig providerConfig;
        protected readonly PublicSectorReportingDataHelper publicSectorReportingDataHelper;
        protected readonly ApprenticeDataHelper apprenticeDataHelper;
        protected readonly EditedApprenticeDataHelper editedApprenticeDataHelper;
        protected readonly EditedApprenticeCourseDataHelper editedApprenticeCourseDataHelper; 
        protected readonly ApprenticeCourseDataHelper apprenticeCourseDataHelper;
        #endregion

        protected ApprovalsBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            regexHelper = context.Get<RegexHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            tabHelper = context.Get<TabHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            registrationConfig = context.GetRegistrationConfig<RegistrationConfig>();
            providerConfig = context.GetProviderConfig<ProviderConfig>();
            approvalsConfig = context.GetApprovalsConfig<ApprovalsConfig>();
            transfersConfig = context.GetTransfersConfig<TransfersConfig>();
            loginCredentialsHelper = context.Get<LoginCredentialsHelper>();
            publicSectorReportingDataHelper = context.Get<PublicSectorReportingDataHelper>();
            apprenticeDataHelper = context.Get<ApprenticeDataHelper>();
            editedApprenticeDataHelper = context.Get<EditedApprenticeDataHelper>();
            apprenticeCourseDataHelper = context.Get<ApprenticeCourseDataHelper>();
            editedApprenticeCourseDataHelper = context.Get<EditedApprenticeCourseDataHelper>();
            if (verifypage) VerifyPage();
        }
    }
}