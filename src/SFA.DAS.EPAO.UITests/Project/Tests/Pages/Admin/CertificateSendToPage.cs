using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class CertificateSendToPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Who would you like us to send the certificate to?";

        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        #region Helpers and Context

        #endregion

        public CertificateSendToPage(ScenarioContext context) : base(context) => VerifyPage();
   
        public CertificateAddressPage ChangeSendToRadioButtonAndContinue(string currentSendTo, string newSendTo)
        {
            switch (currentSendTo)
            {
                case "apprentice":
                    pageInteractionHelper.VerifyRadioOptionSelectedByText("Apprentice", true);
                    break;

                case "employer":
                    pageInteractionHelper.VerifyRadioOptionSelectedByText("Employer", true);
                    break;
            }
            
            switch (newSendTo)
            {
                case "apprentice":
                    formCompletionHelper.SelectRadioOptionByText("Apprentice");
                    break;

                case "employer":
                    formCompletionHelper.SelectRadioOptionByText("Employer");
                    break;
            }
            
            Continue();
            return new CertificateAddressPage(context, "Add");
        }
    }
}