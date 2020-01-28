using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_DAD_1_AuthoriserDetailsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Is your organisation a registered charity?";
        private readonly ScenarioContext _context;

        #region Locators
        private By YesRadioButton => By.Id("CD-26");
        private By CharityNumberTextbox => By.Id("CD-26.1");
        #endregion

        public AP_DAD_1_AuthoriserDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD13_RegisterOfRemovedTrusteesPage EnterCharityDetailsAndContinueInRegisteredCharityPage()
        {
            formCompletionHelper.SelectRadioButton(pageInteractionHelper.FindElement(YesRadioButton));
            formCompletionHelper.EnterText(CharityNumberTextbox, dataHelper.GetRandomNumber(8));
            Continue();
            return new AP_OD13_RegisterOfRemovedTrusteesPage(_context);
        }
    }
}
