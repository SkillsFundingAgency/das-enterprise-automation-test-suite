using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class FindABusinessPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Find a business to fund apprenticeship training";

        public FindABusinessPage(ScenarioContext context) : base(context) { }

        public By StartNowSelector => By.CssSelector("body > div:nth-child(7) > main > div > div > a");

        public Searchfundingopportunitiespage GoToOpportunitiesPage()
        {
            formCompletionHelper.Click(StartNowSelector);
                return new Searchfundingopportunitiespage(context);
        }

    }
}