using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.DfeUat
{
    public class ProvideReceivedDetailsPage : ProvideOrgInformationBasePage
    {
        protected override string PageTitle => "We have received your details";

        protected override By PageHeader => By.CssSelector("h1");

        public ProvideReceivedDetailsPage(ScenarioContext context) : base(context, false) => frameHelper.SwitchFrameAndAction(() => VerifyPage());
    }
}
