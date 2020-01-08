using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderYourCohortsPage : Navigate
    {
        protected override string PageTitle => "Your cohorts";

        protected override string Linktext => "Your cohorts";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By NumberOfCohortsForReview => By.CssSelector(".bold-xxlarge");
        private By NumberOfCohortsWithEmployers => By.XPath("(//h2[@class='bold-xxlarge'])[2]");

        public ProviderYourCohortsPage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ProviderCohortsToReviewPage GoToCohortsToReviewPage()
        {
            var providerReadyForReviewCohorts = Convert.ToInt32(_pageInteractionHelper.GetText(NumberOfCohortsForReview));
            if (providerReadyForReviewCohorts > 0)
            {
                _formCompletionHelper.ClickElement(NumberOfCohortsForReview);
                return new ProviderCohortsToReviewPage(_context);
            }

            throw new Exception("No cohorts available for review");
        }

        internal ProviderCohortsWithEmployersPage GoToCohortsWithEmployers()
        {
            var providerWithEmployerCohorts = Convert.ToInt32(_pageInteractionHelper.GetText(NumberOfCohortsWithEmployers));
            if (providerWithEmployerCohorts > 0)
            {
                _formCompletionHelper.ClickElement(NumberOfCohortsWithEmployers);
                return new ProviderCohortsWithEmployersPage(_context);
            }

            throw new Exception("No cohorts available with employers");
        }
    }
}
