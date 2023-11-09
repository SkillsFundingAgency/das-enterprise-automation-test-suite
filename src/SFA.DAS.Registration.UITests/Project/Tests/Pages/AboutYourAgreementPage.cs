using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AboutYourAgreementPage : InterimYourOrganisationsAndAgreementsPage
    {
        protected override string PageTitle => "About your agreement";

        protected override By ContinueButton => By.CssSelector("input[value='Continue']");

        public AboutYourAgreementPage(ScenarioContext context) : base(context, false) { }

        public SignAgreementPage ClickContinueToYourAgreementButtonInAboutYourAgreementPage()
        {
            Continue();
            return new SignAgreementPage(context);
        }

        public DoYouAcceptTheEmployerAgreementOnBehalfOfPage ClickContinueToYourAgreementButtonToDoYouAcceptTheEmployerAgreementPage()
        {
            Continue();
            return new DoYouAcceptTheEmployerAgreementOnBehalfOfPage (context);
        }
    }
}