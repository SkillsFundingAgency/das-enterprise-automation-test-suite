using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD9_CompanyNumberPage : EPAO_BasePage
    {
        protected override string PageTitle => "Do you have a company number?";
        private readonly ScenarioContext _context;

        #region Locators
        private By CompanyNumberTextbox => By.Id("CD-17.1");
        #endregion

        public AP_OD9_CompanyNumberPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD10_DirectorDetailsPage EnterNumberAndContinueInCompanyNumberPage()
        {
            SelectRadioOptionByForAttribute("CD-17");
            formCompletionHelper.EnterText(CompanyNumberTextbox, dataHelper.GetRandomNumber(8));
            Continue();
            return new AP_OD10_DirectorDetailsPage(_context);
        }
    }
}
