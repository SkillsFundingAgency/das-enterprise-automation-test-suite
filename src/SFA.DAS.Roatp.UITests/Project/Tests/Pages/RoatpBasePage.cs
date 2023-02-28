using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public abstract class RoatpBasePage : VerifyBasePage
    {
        protected override By PageHeader => By.TagName("h1");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        protected static By ChooseFileSelector => By.ClassName("govuk-file-upload");


        protected RoatpBasePage(ScenarioContext context) : base(context) { }

        protected void ChooseFile()
        {
            string File = AppDomain.CurrentDomain.BaseDirectory + frameworkConfig.SampleFileName;
            formCompletionHelper.EnterText(ChooseFileSelector, File);
        }
    }
}
