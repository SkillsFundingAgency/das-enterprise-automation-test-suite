using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAQA.UITests.Project.Tests.Pages.Reviewer
{
    public abstract class RAAQABasePage : VerifyBasePage
    {
        public RAAQABasePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
