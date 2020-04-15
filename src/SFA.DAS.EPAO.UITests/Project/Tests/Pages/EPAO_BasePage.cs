using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages
{
    public abstract class EPAO_BasePage : BasePage
    {
        private readonly FrameworkConfig _frameworkConfig;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly EPAODataHelper dataHelper;
        protected readonly EPAOApplyStandardDataHelper standardDataHelper;
        protected readonly EPAOAdminDataHelper ePAOAdminDataHelper;
        protected readonly EPAOConfig ePAOConfig;
        
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl, .heading-xlarge, .govuk-heading-l, .govuk-panel__title, .govuk-fieldset__heading");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        private By ChooseFile => By.ClassName("govuk-file-upload");

        private By AcceptCookiesButton => By.CssSelector(".das-cookie-banner__button-accept");

        public EPAO_BasePage(ScenarioContext context) : base(context)
        {
            _frameworkConfig = context.Get<FrameworkConfig>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            dataHelper = context.Get<EPAODataHelper>();
            standardDataHelper = context.Get<EPAOApplyStandardDataHelper>();
            ePAOAdminDataHelper = context.Get<EPAOAdminDataHelper>();
            ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
        }

        protected void UploadFile()
        {
            string File = AppDomain.CurrentDomain.BaseDirectory + _frameworkConfig.SampleFileName;
            formCompletionHelper.EnterText(ChooseFile, File);
            Continue();
        }
        
        protected void AcceptCookies() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(AcceptCookiesButton));

        protected void ClickRandomElement(By locator) => formCompletionHelper.ClickElement(() => dataHelper.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(locator)));
    }
}
