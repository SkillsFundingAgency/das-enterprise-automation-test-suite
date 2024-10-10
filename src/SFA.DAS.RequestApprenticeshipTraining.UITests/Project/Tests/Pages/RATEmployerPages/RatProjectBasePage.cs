using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public abstract class RatProjectBasePage(ScenarioContext context) : BasePage(context)
    {
        protected override By ContinueButton => By.CssSelector("[id='main-content'] button.govuk-button[type='submit']");
    }
}