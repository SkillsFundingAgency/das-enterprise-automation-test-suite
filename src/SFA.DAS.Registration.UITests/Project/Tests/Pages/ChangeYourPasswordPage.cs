using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ChangeYourPasswordPage : BasePage
    {
        protected override string PageTitle => "Change your password";

        public ChangeYourPasswordPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}