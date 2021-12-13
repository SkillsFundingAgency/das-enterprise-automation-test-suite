using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class BrowseApprenticeshipPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Browse apprenticeships before you apply";

        private By Route => By.CssSelector("#Route");

        private By Postcode => By.CssSelector("#Postcode");

        protected override By ContinueButton => By.CssSelector("#search-apprenticeship");

        public BrowseApprenticeshipPage(ScenarioContext context) : base(context)  { }

        public ResultsPage SearchForAnApprenticeship()
        {
            formCompletionHelper.SelectFromDropDownByText(Route, "Digital");
            formCompletionHelper.EnterText(Postcode, "CV1 2WT");
            Continue();
            return new ResultsPage(context);
        }
    }
}
