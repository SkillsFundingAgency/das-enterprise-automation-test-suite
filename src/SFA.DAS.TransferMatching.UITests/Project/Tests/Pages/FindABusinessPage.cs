using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class FindABusinessPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "Find a business to fund apprenticeship training";

        public static By StartNowSelector => By.LinkText("Start now");

        public Searchfundingopportunitiespage GoToOpportunitiesPage()
        {
            formCompletionHelper.Click(StartNowSelector);
            return new Searchfundingopportunitiespage(context);
        }

    }
}