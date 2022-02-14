using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class CertificateAddressPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => $"{PageTitlePrefix} the address that you'd like us to send the certificate to";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        private string PageTitlePrefix { get; set; }

        #region Helpers and Context

        #endregion

        public CertificateAddressPage(ScenarioContext context, string pageTitlePrefix)
            : base(context)
        {
            PageTitlePrefix = pageTitlePrefix;
            VerifyPage(); 
        }

        public CertificateAddressPage EnterRecipientName(string recipientName)
        {
            formCompletionHelper.EnterText(By.Id("Name"), recipientName);
            return this;
        }

        public CertificateAddressPage EnterRecipientDepartment(string department)
        {
            formCompletionHelper.EnterText(By.Id("Dept"), department);
            return this;
        }

        public CertificateAddressPage EnterEmployerName(string employer)
        {
            formCompletionHelper.EnterText(By.Id("Employer"), employer);
            return this;
        }

        public CertificateAddressPage EnterAddress(string addressLine1, string addressLine2, string addressLine3, string city, string postcode)
        {
            formCompletionHelper.EnterText(By.Id("AddressLine1"), addressLine1);
            formCompletionHelper.EnterText(By.Id("AddressLine2"), addressLine2);
            formCompletionHelper.EnterText(By.Id("AddressLine3"), addressLine3);
            formCompletionHelper.EnterText(By.Id("City"), city);
            formCompletionHelper.EnterText(By.Id("Postcode"), postcode);
            return this;
        }
        
        public CheckAndSubmitAssessmentDetailsPage EnterReasonForChangeAndContinue(string reasonForChange)
        {
            formCompletionHelper.EnterText(By.Id("ReasonForChange"), reasonForChange);
            Continue();
            return new CheckAndSubmitAssessmentDetailsPage(context);
        }
    }
}