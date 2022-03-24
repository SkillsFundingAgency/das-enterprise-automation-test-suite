using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class FindABusinessPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Find a business to fund apprenticeship training";

        public FindABusinessPage(ScenarioContext context) : base(context) { }

        public By StartNowSelector => By.LinkText("Start now");

        public Searchfundingopportunitiespage GoToOpportunitiesPage()
        {
            formCompletionHelper.Click(StartNowSelector);
                return new Searchfundingopportunitiespage(context);
        }

    }
}