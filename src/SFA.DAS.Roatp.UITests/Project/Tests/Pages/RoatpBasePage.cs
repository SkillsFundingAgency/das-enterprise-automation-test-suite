using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public abstract class RoatpBasePage : BasePage
    {
        protected override By PageHeader => By.TagName("h1");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        protected By ChooseFileSelector => By.ClassName("govuk-file-upload");

        #region Helpers and Context
        protected readonly RoatpConfig roatpConfig;
        #endregion

        protected RoatpBasePage(ScenarioContext context) : base(context) => roatpConfig = context.GetRoatpConfig<RoatpConfig>();

        protected void ChooseFile()
        {
            string File = AppDomain.CurrentDomain.BaseDirectory + _frameworkConfig.SampleFileName;
            formCompletionHelper.EnterText(ChooseFileSelector, File);
        }
    }
}
