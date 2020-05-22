using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public abstract class PublicSectorReportingBasePage : BasePage
    {
        protected By LabelCssSelector => By.CssSelector("label.form-label-bold");

        protected By Textarea => By.CssSelector("textarea");

        protected override By ContinueButton => By.CssSelector("button.button[type='submit']");

        #region Helpers and Context
        protected readonly TabHelper tabHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        protected readonly RegistrationConfig registrationConfig;
        protected readonly PublicSectorReportingDataHelper dataHelper;
        #endregion

        public PublicSectorReportingBasePage(ScenarioContext context) : base(context)
        {
            tabHelper = context.Get<TabHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            registrationConfig = context.Get<RegistrationConfig>();
            dataHelper = context.Get<PublicSectorReportingDataHelper>();
        }
    }
}