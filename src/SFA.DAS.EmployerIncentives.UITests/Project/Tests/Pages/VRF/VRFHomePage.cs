using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFHomePage : EIBasePage
    {
        protected override string PageTitle => "Department for Education";
        protected override By PageHeader => By.CssSelector("#homepageContent");

        public VRFHomePage(ScenarioContext context) : base(context) { }
    }
}
