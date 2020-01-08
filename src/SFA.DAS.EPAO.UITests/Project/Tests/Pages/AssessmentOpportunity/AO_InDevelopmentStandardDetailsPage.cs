using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity
{
    public class AO_InDevelopmentStandardDetailsPage : BasePage
    {
        protected override string PageTitle => "Blacksmith";

        public AO_InDevelopmentStandardDetailsPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }

        public AO_InDevelopmentStandardDetailsPage VerifyInDevelopmentStandardDetailsPage()
        {
            return this;
        }
    }
}
