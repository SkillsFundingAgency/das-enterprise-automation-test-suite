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
            formCompletionHelper.EnterText(CertificateRecipientName, recipientName);
            return this;
        }

        public CertificateAddressPage EnterRecipientDepartment(string department)
        {
            formCompletionHelper.EnterText(CertificateRecipientDepartment, department);
            return this;
        }

        public CertificateAddressPage EnterEmployerName(string employer)
        {
            formCompletionHelper.EnterText(CertificateEmployerName, employer);
            return this;
        }

        public CertificateAddressPage EnterAddress(string addressLine1, string addressLine2, string addressLine3, string city, string postcode)
        {
            formCompletionHelper.EnterText(CertificateAddresLine1, addressLine1);
            formCompletionHelper.EnterText(CertificateAddresLine2, addressLine2);
            formCompletionHelper.EnterText(CertificateAddresLine3, addressLine3);
            formCompletionHelper.EnterText(CertificateCity, city);
            formCompletionHelper.EnterText(CertificatePostcode, postcode);
            return this;
        }
        
        public CheckAndSubmitAssessmentDetailsPage EnterReasonForChangeAndContinue(string reasonForChange)
        {
            formCompletionHelper.EnterText(CertificateReasonForChange, reasonForChange);
            Continue();
            return new CheckAndSubmitAssessmentDetailsPage(context);
        }
    }
}