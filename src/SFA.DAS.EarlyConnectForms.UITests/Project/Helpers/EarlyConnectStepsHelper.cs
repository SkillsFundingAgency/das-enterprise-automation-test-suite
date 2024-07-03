using SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Helpers
{
    public class EarlyConnectStepsHelper(ScenarioContext context)
    {
        public EarlyConnectHomePage GoToEarlyConnectHomePage()
        {
            return new EarlyConnectHomePage(context).AcceptCookieAndAlert();
        }

        public EarlyConnectHomePage GoToEarlyConnectAdvisorPage()
        {
            return new EarlyConnectHomePage(context).SelectNorthEast();
        }

        public GetApprenticeshipAdviserPage GoToEarlyConnectEmailPage()
        {
            return new GetApprenticeshipAdviserPage(context).GoToEmailAddressPage();
        }

        public EmailAuthCodePage GoToCheckEmailCodePage()
        {
            return  new EmailAddressPage(context).EnterNewEmailAddress();
        }
        public WhatsYourNamePage GoToCheckEmailCodePage1()
        {
            return new EmailAuthCodePage(context).EnterValidAuthCode();
        }

        public DateOfBirthPage GoToCheckEmailCodePage2()
        {
            return new WhatsYourNamePage(context).EnterFirstAndLastNames();
        }

        public PostcodePage GoToWhatIsYourDateOfBirthPage()
        {
            return new DateOfBirthPage(context).EnterValidDateOfBirth();
        }

        public PostcodePage GoToPostCodePage()
        {
            return new PostcodePage(context).EnterValidPostcode();
        }

    }
}
