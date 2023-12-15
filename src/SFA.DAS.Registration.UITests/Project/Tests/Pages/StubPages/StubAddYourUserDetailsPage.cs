using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages
{
    public class StubAddYourUserDetailsPage(ScenarioContext context) : StubAddYourUserDetailsBasePage(context)
    {
        public ConfirmYourUserDetailsPage EnterNameAndContinue(RegistrationDataHelper dataHelper)
        {
            EnterNameAndContinue(dataHelper.FirstName, dataHelper.LastName);

            return new ConfirmYourUserDetailsPage(context);
        }

        public ConfirmYourUserDetailsPage DoNotEnterNameAndContinue()
        {
            Continue();
            return new ConfirmYourUserDetailsPage(context);
        }
    }
}
