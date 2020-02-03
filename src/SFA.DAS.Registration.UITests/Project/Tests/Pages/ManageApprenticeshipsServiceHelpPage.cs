using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ManageApprenticeshipsServiceHelpPage : BasePage
    {
        protected override string PageTitle => "Help articles";

        public ManageApprenticeshipsServiceHelpPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}