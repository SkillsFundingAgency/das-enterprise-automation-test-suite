using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
   public class AdviceForParentPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Page not found";
        public AdviceForParentPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}