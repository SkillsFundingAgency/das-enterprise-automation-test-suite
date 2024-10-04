using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerHubPage(ScenarioContext context) : EmployerBasePage(context)
    {
        protected override string PageTitle => "Employers";

        protected override By PageHeader => PageHeaderTag;

        protected static By SearchForAnApprenticeship => By.CssSelector("#fiu-panel-link-fat");

        protected static By UnderstandingApprenticeshipBenefitsAndFunding => By.CssSelector("a[href='/employers/understanding-apprenticeship-benefits-and-funding']");

        protected static By EmployerSignUpButton => By.CssSelector("a[href='/employers/sign-up']");

        public void VerifySubHeadings() => VerifyFiuCards(() => NavigateToEmployerHubPage());

        public UnderstandingApprenticeshipBenefitsFundingPage NavigateToUnderstandingApprenticeshipBenefitsAndFunding()
        {
            formCompletionHelper.ClickElement(UnderstandingApprenticeshipBenefitsAndFunding);
            return new UnderstandingApprenticeshipBenefitsFundingPage(context);
        }

        public SearchForAnApprenticeshipPage NavigateToFindAnApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(SearchForAnApprenticeship);
            return new SearchForAnApprenticeshipPage(context);
        }

        public SignUpPage NavigateToSignUpPage()
        {
            formCompletionHelper.ClickElement(EmployerSignUpButton);
            return new SignUpPage(context);
        }
    }
}
