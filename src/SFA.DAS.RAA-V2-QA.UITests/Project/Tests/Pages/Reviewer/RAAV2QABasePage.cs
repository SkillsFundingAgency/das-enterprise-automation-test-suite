using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer
{
    public abstract class RAAV2QABasePage : VerifyBasePage
    {
        public RAAV2QABasePage(ScenarioContext context) : base(context) => VerifyPage(); 
    }
}
