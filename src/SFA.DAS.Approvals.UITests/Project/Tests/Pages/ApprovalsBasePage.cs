using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.ProviderLogin.Service.Project;
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
        protected readonly ApprenticeCourseDataHelper apprenticeCourseDataHelper;
        protected readonly RegistrationDataHelper registrationDataHelper;
        protected readonly PortableFlexiJobProviderConfig portableFlexiJobProviderConfig;
        #endregion

        private By TrainingCourseEditLink => By.CssSelector("button[name='ChangeCourse']");

        protected ApprovalsBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            registrationDataHelper = context.Get<RegistrationDataHelper>();
            providerConfig = context.GetProviderConfig<ProviderConfig>();
            approvalsConfig = context.GetApprovalsConfig<ApprovalsConfig>();
            changeOfPartyConfig = context.GetChangeOfPartyConfig<ChangeOfPartyConfig>();
            portableFlexiJobProviderConfig = context.GetPortableFlexiJobProviderConfig<PortableFlexiJobProviderConfig>();
            loginCredentialsHelper = context.Get<LoginCredentialsHelper>();
            publicSectorReportingDataHelper = context.GetValue<PublicSectorReportingDataHelper>();
            apprenticeDataHelper = context.GetValue<ApprenticeDataHelper>();
            editedApprenticeDataHelper = context.GetValue<EditedApprenticeDataHelper>();
            apprenticeCourseDataHelper = context.GetValue<ApprenticeCourseDataHelper>();
            if (verifypage) VerifyPage();
        }

        public SelectStandardPage ClickEditCourseLink()
        {
            formCompletionHelper.Click(TrainingCourseEditLink);
            return new SelectStandardPage(context);
        }

        protected bool IsSelectStandardWithMultipleOptions() => tags.Contains("selectstandardwithmultipleoptions");
    }
}