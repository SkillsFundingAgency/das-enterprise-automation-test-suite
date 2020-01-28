using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD11_DirectorsDataPage : EPAO_BasePage
    {
        protected override string PageTitle => "Directors data";
        private readonly ScenarioContext _context;

        #region Locators
        private By NoRadioButton => By.Id("CD-22_1");
        #endregion

        public AP_OD11_DirectorsDataPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DAD_1_AuthoriserDetailsPage SelectNoOptionAndContinueInDirectorsDataPage()
        {
            formCompletionHelper.SelectRadioButton(pageInteractionHelper.FindElement(NoRadioButton));
            Continue();
            return new AP_DAD_1_AuthoriserDetailsPage(_context);
        }
    }
}
