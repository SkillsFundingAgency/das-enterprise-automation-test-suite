using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_AddEmployerAddress : EPAO_BasePage
    {
        protected override string PageTitle => "Add the address that you’d like us to send the certificate to";

        private readonly ScenarioContext _context;

        #region Locators
        private By CompanyNameTextBox => By.Id("Employer");
        private By AddressLine1TextBox => By.Id("AddressLine1");
        private By AddressLine2TextBox => By.Id("AddressLine2");
        private By AddressLine3TextBox => By.Id("AddressLine3");
        private By TownOrCityTextBox => By.Id("City");
        private By PostCodeTextBox => By.Id("Postcode");
        #endregion

        public AS_AddEmployerAddress(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_ConfirmAddressPage EnterEmployerAddressAndContinue()
        {
            formCompletionHelper.EnterText(CompanyNameTextBox, "ESFA");
            formCompletionHelper.EnterText(AddressLine1TextBox, "5");
            formCompletionHelper.EnterText(AddressLine2TextBox, "QuintonRoad");
            formCompletionHelper.EnterText(AddressLine3TextBox, "C House");
            formCompletionHelper.EnterText(TownOrCityTextBox, "Coventry");
            formCompletionHelper.EnterText(PostCodeTextBox, "CV1 2WT");
            Continue();
            return new AS_ConfirmAddressPage(_context);
        }
    }
}