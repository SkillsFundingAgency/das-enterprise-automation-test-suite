using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages
{
    public class PAYESchemeDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "PAYE scheme";
        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");

        #region Locators
        private By RemovePAYESchemeButton => By.LinkText("Remove PAYE scheme");
        #endregion

        public PAYESchemeDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public RemoveThisSchemePage ClickRemovePAYESchemeButton()
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(RemovePAYESchemeButton));
            return new RemoveThisSchemePage(_context);
        }
    }
}
