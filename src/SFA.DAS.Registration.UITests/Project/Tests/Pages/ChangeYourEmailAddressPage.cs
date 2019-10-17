using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ChangeYourEmailAddressPage : BasePage
    {
        protected override string PageTitle => "Change your email address";

        public ChangeYourEmailAddressPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}