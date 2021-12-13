
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class DoYouNeedToCreateAnAdvertPage : DoYouNeedToCreateAnAdvertBasePage
    {
        public DoYouNeedToCreateAnAdvertPage(ScenarioContext context) : base(context)  { }

        public AddAnApprenitcePage ClickNoRadioButtonTakesToAddAnApprentices()
        {
            formCompletionHelper.ClickElement(NoRadioButtonOption);
            Continue();
            return new AddAnApprenitcePage(_context);
        }
    }
}
