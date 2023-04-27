using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public abstract class AanBasePage : VerifyBasePage
    {
        protected override By PageHeader => By.TagName("h1");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");


        protected AanBasePage(ScenarioContext context) : base(context) => VerifyPage();

    }
}

