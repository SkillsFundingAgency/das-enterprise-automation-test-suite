using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class FindABusinessPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Find a business to fund apprenticeship training";

        public FindABusinessPage(ScenarioContext context) : base(context) { }
    }
}