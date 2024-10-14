using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public abstract class RatProjectBasePage : VerifyBasePage
    {
        protected RatProjectBasePage(ScenarioContext context, bool verifyPage = true) : base(context) { if (verifyPage) VerifyPage(); }
        
        protected override By ContinueButton => By.CssSelector("[id='main-content'] button.govuk-button[type='submit']");
    }
}