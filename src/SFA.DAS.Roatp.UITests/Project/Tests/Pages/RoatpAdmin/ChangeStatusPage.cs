using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ChangeStatusPage : ChangeBasePage
    {
        protected override string PageTitle => $"Change status for {objectContext.GetProviderName()}";

        public ChangeStatusPage(ScenarioContext context) : base(context) { }

    }
}
