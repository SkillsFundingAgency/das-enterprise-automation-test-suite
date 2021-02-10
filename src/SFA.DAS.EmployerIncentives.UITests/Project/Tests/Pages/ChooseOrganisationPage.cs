using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ChooseOrganisationPage : EIBasePage
    {
        protected override string PageTitle => "Choose organisation";

        #region Locators
        private readonly ScenarioContext _context;
        private By FirstRadioButton => By.XPath("//input[@name='Selected']");
        #endregion

        public ChooseOrganisationPage(ScenarioContext context) : base(context) => _context = context;

        public EIStartPage SelectFirstEntityInChooseOrgPageAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(FirstRadioButton));
            formCompletionHelper.Click(ContinueButton);
            return new EIStartPage(_context);
        }
    }
}
