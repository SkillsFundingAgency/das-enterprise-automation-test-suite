using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAQA.UITests.Project.Tests.Pages.Reviewer
{
    public abstract class RAAV2QABasePage : VerifyBasePage
    {
        public RAAV2QABasePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
