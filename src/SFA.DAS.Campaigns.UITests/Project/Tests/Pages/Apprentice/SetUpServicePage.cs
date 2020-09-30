using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class SetUpServicePage:ApprenticeBasePage
    {
        protected override string PageTitle => "Create an account on find an apprenticeship";
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        public SetUpServicePage(ScenarioContext context): base(context) { }
    }
}