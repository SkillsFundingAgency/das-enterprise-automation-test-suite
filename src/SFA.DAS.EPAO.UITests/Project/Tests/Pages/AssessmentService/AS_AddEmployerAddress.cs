using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_AddEmployerAddress : EPAO_BasePage
    {
        protected override string PageTitle => "Add the address that you’d like us to send the certificate to";

        #region Locators
        private By EmployerNameTextBox => By.Id("Employer");
        private By AddressLine1TextBox => By.Id("AddressLine1");
        private By AddressLine2TextBox => By.Id("AddressLine2");
        private By AddressLine3TextBox => By.Id("AddressLine3");
        private By TownOrCityTextBox => By.Id("City");
        private By PostCodeTextBox => By.Id("Postcode");
        private By SaveContinueButton => By.XPath("(//button[@type='submit'])[3]");
        #endregion

        public AS_AddEmployerAddress(ScenarioContext context) : base(context) => VerifyPage();

        public AS_ConfirmAddressPage EnterEmployerAddressAndContinue()
        {
            EnterAddressAndContinue();
            return new AS_ConfirmAddressPage(context);
        }

        public AS_AddRecipientsDetailsPage EnterEmployerNameAndAddressAndContinue()
        {
            EnterText(EmployerNameTextBox, "Nasdaq");
            EnterAddressAndContinue();
            return new AS_AddRecipientsDetailsPage(context);
        }

        private void EnterAddressAndContinue()
        {
            EnterText(AddressLine1TextBox, ePAOAdminDataHelper.AddressLine1);
            EnterText(AddressLine2TextBox, ePAOAdminDataHelper.AddressLine2);
            EnterText(AddressLine3TextBox, ePAOAdminDataHelper.AddressLine3);
            EnterText(TownOrCityTextBox, ePAOAdminDataHelper.TownName);
            EnterText(PostCodeTextBox, ePAOAdminDataHelper.PostCode);
            formCompletionHelper.Click(SaveContinueButton);
        }

        private void EnterText(By locator, string text) => formCompletionHelper.EnterText(locator, text);
    }
}