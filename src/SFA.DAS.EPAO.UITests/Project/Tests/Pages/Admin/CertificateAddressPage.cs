using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class CertificateAddressPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => $"{PageTitlePrefix} the address that you'd like us to send the certificate to";
        
        private string PageTitlePrefix { get; set; }

        #region Helpers and Context
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        private By CertificateRecipientName => By.Id("Name");
        private By CertificateRecipientDepartment => By.Id("Dept");
        private By CertificateEmployerName => By.Id("Employer");
        private By CertificateAddresLine1 => By.Id("AddressLine1");
        private By CertificateAddresLine2 => By.Id("AddressLine2");
        private By CertificateAddresLine3 => By.Id("AddressLine3");
        private By CertificateCity => By.Id("City");
        private By CertificatePostcode => By.Id("Postcode");
        private By CertificateReasonForChange => By.Id("ReasonForChange");
        #endregion

        public CertificateAddressPage(ScenarioContext context, string pageTitlePrefix) : base(context)
        {
            PageTitlePrefix = pageTitlePrefix;
            VerifyPage(); 
        }

        public CertificateAddressPage EnterRecipientName(string recipientName)
        {
            EnterText(CertificateRecipientName, recipientName);
            return this;
        }

        public CertificateAddressPage EnterRecipientDepartment(string department)
        {
            EnterText(CertificateRecipientDepartment, department);
            return this;
        }

        public CertificateAddressPage EnterEmployerName(string employer)
        {
            EnterText(CertificateEmployerName, employer);
            return this;
        }

        public CertificateAddressPage EnterAddress()
        {
            EnterText(CertificateAddresLine1, ePAOAdminDataHelper.AddressLine1);
            EnterText(CertificateAddresLine2, ePAOAdminDataHelper.AddressLine2);
            EnterText(CertificateAddresLine3, ePAOAdminDataHelper.AddressLine3);
            EnterText(CertificateCity, ePAOAdminDataHelper.TownName);
            EnterText(CertificatePostcode, ePAOAdminDataHelper.PostCode);
            return this;
        }
        
        public CheckAndSubmitAssessmentDetailsPage EnterReasonForChangeAndContinue(string reasonForChange)
        {
            EnterText(CertificateReasonForChange, reasonForChange);
            Continue();
            return new CheckAndSubmitAssessmentDetailsPage(context);
        }

        private void EnterText(By locator, string text) => formCompletionHelper.EnterText(locator, text);
    }
}