using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD10_DirectorDetailsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Director details";
        private readonly ScenarioContext _context;

        #region Locators
        private By FullNameTextbox => By.Id("CD-19");
        private By MonthTextbox => By.Id("CD-20_Month");
        private By YearTextbox => By.Id("CD-20_Year");
        private By NumberOfSharesTextbox => By.Id("CD-21");
        private By SaveAndAddAnotherLink => By.XPath("//button[text()='Save and add another']");
        #endregion

        public AP_OD10_DirectorDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD11_DirectorsDataPage EnterNumberAndContinueInDirectoDetailsPage()
        {
            formCompletionHelper.EnterText(FullNameTextbox, dataHelper.GetRandomAlphabeticString(20));
            formCompletionHelper.EnterText(MonthTextbox, dataHelper.GetCurrentMonth);
            formCompletionHelper.EnterText(YearTextbox, dataHelper.GetCurrentYear - 30);
            formCompletionHelper.EnterText(NumberOfSharesTextbox, dataHelper.GetRandomNumber(3));
            formCompletionHelper.Click(SaveAndAddAnotherLink);
            Continue();
            return new AP_OD11_DirectorsDataPage(_context);
        }
    }
}
