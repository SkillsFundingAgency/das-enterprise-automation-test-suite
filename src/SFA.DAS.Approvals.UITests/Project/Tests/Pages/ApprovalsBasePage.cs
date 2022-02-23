using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages
{
    public abstract class ApprovalsBasePage : VerifyBasePage
    {
        #region Helpers and Context
        protected readonly LoginCredentialsHelper loginCredentialsHelper;
        protected readonly ApprovalsConfig approvalsConfig;
        protected readonly ProviderConfig providerConfig;
        protected readonly ChangeOfPartyConfig changeOfPartyConfig;
        protected readonly PublicSectorReportingDataHelper publicSectorReportingDataHelper;
        protected readonly ApprenticeDataHelper apprenticeDataHelper;
        protected readonly EditedApprenticeDataHelper editedApprenticeDataHelper;
        protected readonly EditedApprenticeCourseDataHelper editedApprenticeCourseDataHelper; 
        protected readonly ApprenticeCourseDataHelper apprenticeCourseDataHelper;
        protected readonly RegistrationDataHelper registrationDataHelper; 
        #endregion

        protected ApprovalsBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            registrationDataHelper = context.Get<RegistrationDataHelper>();
            providerConfig = context.GetProviderConfig<ProviderConfig>();
            approvalsConfig = context.GetApprovalsConfig<ApprovalsConfig>();
            changeOfPartyConfig = context.GetChangeOfPartyConfig<ChangeOfPartyConfig>();
            loginCredentialsHelper = context.Get<LoginCredentialsHelper>();
            publicSectorReportingDataHelper = context.GetValue<PublicSectorReportingDataHelper>();
            apprenticeDataHelper = context.GetValue<ApprenticeDataHelper>();
            editedApprenticeDataHelper = context.GetValue<EditedApprenticeDataHelper>();
            apprenticeCourseDataHelper = context.GetValue<ApprenticeCourseDataHelper>();
            editedApprenticeCourseDataHelper = context.GetValue<EditedApprenticeCourseDataHelper>();
            if (verifypage) VerifyPage();
        }

        protected bool IsSelectStandardWithMultipleOptions() => tags.Contains("selectstandardwithmultipleoptions");
    }
}