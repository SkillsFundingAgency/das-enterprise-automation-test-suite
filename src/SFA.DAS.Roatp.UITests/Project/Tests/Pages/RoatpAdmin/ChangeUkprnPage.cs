using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ChangeUkprnPage : ChangeBasePage
    {
        protected override string PageTitle => $"Change UKPRN for {objectContext.GetProviderName()}";

        public ChangeUkprnPage(ScenarioContext context) : base(context) { }
    }
}
