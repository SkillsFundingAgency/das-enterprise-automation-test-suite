using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class NewStopDateApprenticeDetailsPage : ApprenticeDetailsPage
    {
        protected override string PageTitle => "New stop date confirmed";
        protected override By PageHeader => By.CssSelector(".heading-large");

        public NewStopDateApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}