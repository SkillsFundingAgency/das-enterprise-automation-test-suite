using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderYourCntctInfoForThisStandardPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Your contact information for this standard";
        private By EMailAddress => By.Name("ContactUsEmail");
        private By TelephoneNumber => By.Name("ContactUsPhoneNumber");
        private By ContactPage => By.Name("ContactUsPageUrl");
        private By YourWebsitePage => By.Name("StandardInfoUrl");

        public ProviderYourCntctInfoForThisStandardPage(ScenarioContext context) : base(context) { }

        public ProviderWhereWillThisStandardBeDeliveredPage AddContactInfo()
        {
            formCompletionHelper.EnterText(EMailAddress, "test@test.com");
            formCompletionHelper.EnterText(TelephoneNumber, "01212253561");
            formCompletionHelper.EnterText(ContactPage, "www.test.co.uk");
            formCompletionHelper.EnterText(YourWebsitePage, "www.test.co.uk");
            Continue();
            return new ProviderWhereWillThisStandardBeDeliveredPage(context);
        }
    }
}
