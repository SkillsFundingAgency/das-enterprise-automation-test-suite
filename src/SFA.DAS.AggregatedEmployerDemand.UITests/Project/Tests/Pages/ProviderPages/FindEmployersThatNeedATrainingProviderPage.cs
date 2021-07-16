using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class FindEmployersThatNeedATrainingProviderPage : AEDBasePage
    {
        protected override string PageTitle => "Find employers that need a training provider";
        private readonly ScenarioContext _context;
        public FindEmployersThatNeedATrainingProviderPage(ScenarioContext context) : base(context) => _context = context;

        private By FindEmployersThatNeedATrainingProviderLink => By.LinkText("Find employers that need a training provider");
        private By SelectFirstViewEmployerLink => By.Id("view-274");

        public FindEmployersThatNeedATrainingProviderPage ViewFindEmployersThatNeedATrainingProvider()
        {
            formCompletionHelper.ClickElement(FindEmployersThatNeedATrainingProviderLink);
            return new FindEmployersThatNeedATrainingProviderPage(_context);
        }

        public WhichEmployersAreYouInterestedInPage ViewWhichEmployerNeedsATrainingProvider()
        {
            formCompletionHelper.ClickElement(SelectFirstViewEmployerLink);
            return new WhichEmployersAreYouInterestedInPage(_context);
        }
    }
}
