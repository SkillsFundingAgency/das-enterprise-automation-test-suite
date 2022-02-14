using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class CheckAndSubmitAssessmentDetailsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Check and submit the assessment details";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        private By SendToChangeLink => By.XPath("//a[starts-with(@href, '/CertificateSendTo/SendTo')]");

        #region Helpers and Context

        #endregion

        public CheckAndSubmitAssessmentDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public CertificateSendToPage ClickChangeSendToLink()
        {
            formCompletionHelper.ClickElement(SendToChangeLink);
            return new CertificateSendToPage(context);
        }

        public ConfirmationAmendPage ClickConfirmAmend()
        {
            Confirm();
            return new ConfirmationAmendPage(context);
        }

        public ConfirmationReprintPage ClickConfirmReprint()
        {
            Confirm();
            return new ConfirmationReprintPage(context);
        }

        public void VerifyRecipient(string recipient)
        {
            pageInteractionHelper.VerifyText(GetBySummaryValueLocator("Recipient's Name"), recipient);
        }

        public void VerifyEmployer(string employer)
        {
            pageInteractionHelper.VerifyText(GetBySummaryValueLocator("Address"), employer);
        }

        public void VerifyRecipientIsApprentice()
        {
            var givenName = pageInteractionHelper.GetText(GetBySummaryValueLocator("Given name"));
            var familyName = pageInteractionHelper.GetText(GetBySummaryValueLocator("Family name"));
            
            pageInteractionHelper.VerifyText(GetBySummaryValueLocator("Recipient's Name"), $"{givenName} {familyName}");
        }

        private By GetBySummaryValueLocator(string displayName)
        {
            return By.XPath($"//dt[contains(text(),\"{displayName}\")]/following-sibling::dd[@class='govuk-summary-list__value']");
        }
    }
}