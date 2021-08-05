using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeHowDoTheyWorkPage : ApprenticeBasePage
    {
        protected override string PageTitle => "How do they work?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion


        public ApprenticeHowDoTheyWorkPage(ScenarioContext context) : base(context) => _context = context;

        public void VerifyHowDoTheyWorkPageSubHeadings() => VerifyFiuCards(() => NavigateToHowDoTheyWorkPage());
        
    }
}