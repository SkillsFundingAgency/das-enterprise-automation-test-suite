using SFA.DAS.RAAEmployer.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAEmployer.UITests.Project.Tests.Pages.DynamicHomePageEmployer
{
    class DoYouNeedToCreateAnAdvertPage(ScenarioContext context) : DoYouNeedToCreateAnAdvertBasePage(context)
    {
        public CreateAnAdvertHomePage ClickYesRadioButtonTakesToRecruitment()
        {
            formCompletionHelper.ClickElement(YesRadioButtonOption);
            Continue();
            return new CreateAnAdvertHomePage(context);
        }
    }
}
