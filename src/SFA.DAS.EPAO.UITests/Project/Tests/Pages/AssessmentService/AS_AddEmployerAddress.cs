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
            EnterAddressLine1("5");
            EnterAddressLine2("QuintonRoad");
            EnterAddressLine3("C House");
            EnterTownOrCity("Coventry");
            EnterPostCode("CV1 2WT");
            SaveAndContinue();
            return new AS_ConfirmAddressPage(context);
        }

        public AS_AddRecipientsDetailsPage EnterEmployerNameAndAddressAndContinue()
        {
            EnterText(EmployerNameTextBox, "Nasdaq");
            EnterAddressLine1("5");
            EnterAddressLine2("QuintonRoad");
            EnterAddressLine3("C House");
            EnterTownOrCity("Coventry");
            EnterPostCode("CV1 2WT");
            SaveAndContinue();
            return new AS_AddRecipientsDetailsPage(context);
        }

        private void EnterAddressLine1(string text) => EnterText(AddressLine1TextBox, text);
        private void EnterAddressLine2(string text) => EnterText(AddressLine2TextBox, text);
        private void EnterAddressLine3(string text) => EnterText(AddressLine3TextBox, text);
        private void EnterTownOrCity(string text) => EnterText(TownOrCityTextBox, text);
        private void EnterPostCode(string text) => EnterText(PostCodeTextBox, text);
        private void EnterText(By locator, string text) => formCompletionHelper.EnterText(locator, text);
        private void SaveAndContinue() => formCompletionHelper.Click(SaveContinueButton);
    }
}