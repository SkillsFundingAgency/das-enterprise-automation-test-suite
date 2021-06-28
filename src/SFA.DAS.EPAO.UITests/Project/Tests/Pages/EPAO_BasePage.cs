using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages
{
    public abstract class EPAO_BasePage : BasePage
    {
        private readonly FrameworkConfig _frameworkConfig;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly EPAOApplyDataHelper ePAOApplyDataHelper;
        protected readonly EPAOAssesmentServiceDataHelper ePAOAssesmentServiceDataHelper;
        protected readonly EPAOApplyStandardDataHelper standardDataHelper;
        protected readonly EPAOAdminDataHelper ePAOAdminDataHelper;
        protected readonly EPAOConfig ePAOConfig;
        protected readonly ObjectContext objectContext;  

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl, .heading-xlarge, .govuk-heading-l, .govuk-panel__title, .govuk-fieldset__heading, .govuk-label--xl");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        protected override By AcceptCookieButton => By.CssSelector(".das-cookie-banner__button-accept");

        private By ChooseFile => By.ClassName("govuk-file-upload");

        private By SummaryRows => By.CssSelector(".govuk-summary-list__row");

        public EPAO_BasePage(ScenarioContext context) : base(context)
        {
            _frameworkConfig = context.Get<FrameworkConfig>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            ePAOApplyDataHelper = context.Get<EPAOApplyDataHelper>();
            ePAOAssesmentServiceDataHelper = context.Get<EPAOAssesmentServiceDataHelper>();
            standardDataHelper = context.Get<EPAOApplyStandardDataHelper>();
            ePAOAdminDataHelper = context.Get<EPAOAdminDataHelper>();
            ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
            objectContext = context.Get<ObjectContext>();
        }

        public virtual bool VerifyGrade(string grade) => pageInteractionHelper.FindElements(SummaryRows).ToList().Any(x => x.Text.Contains("Grade") && x.Text.ContainsCompareCaseInsensitive(grade));

        protected void UploadFile()
        {
            string File = AppDomain.CurrentDomain.BaseDirectory + _frameworkConfig.SampleFileName;
            formCompletionHelper.EnterText(ChooseFile, File);
            Continue();
        }
               
        protected void ClickRandomElement(By locator) => formCompletionHelper.ClickElement(() => ePAOAdminDataHelper.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(locator)));
    }
}
