using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages
{
    public abstract class EPAO_BasePage : VerifyBasePage
    {
        protected readonly EPAOApplyDataHelper ePAOApplyDataHelper;
        protected readonly EPAOAssesmentServiceDataHelper ePAOAssesmentServiceDataHelper;
        protected readonly EPAOApplyStandardDataHelper standardDataHelper;
        protected readonly EPAOAdminDataHelper ePAOAdminDataHelper;
                
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl, .heading-xlarge, .govuk-heading-l, .govuk-panel__title, .govuk-fieldset__heading, .govuk-label--xl");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        protected override By AcceptCookieButton => By.CssSelector(".das-cookie-banner__button-accept");

        private By ChooseFile => By.ClassName("govuk-file-upload");

        private By SummaryRows => By.CssSelector(".govuk-summary-list__row");

        public EPAO_BasePage(ScenarioContext context) : base(context)
        {
            ePAOApplyDataHelper = context.Get<EPAOApplyDataHelper>();
            ePAOAssesmentServiceDataHelper = context.Get<EPAOAssesmentServiceDataHelper>();
            standardDataHelper = context.Get<EPAOApplyStandardDataHelper>();
            ePAOAdminDataHelper = context.Get<EPAOAdminDataHelper>();
        }

        public virtual bool VerifyGrade(string grade) => pageInteractionHelper.FindElements(SummaryRows).ToList().Any(x => x.Text.Contains("Grade") && x.Text.ContainsCompareCaseInsensitive(grade));

        protected void UploadFile()
        {
            string File = AppDomain.CurrentDomain.BaseDirectory + frameworkConfig.SampleFileName;
            formCompletionHelper.EnterText(ChooseFile, File);
            Continue();
        }
               
        protected void ClickRandomElement(By locator) => formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(locator)));
    }
}
