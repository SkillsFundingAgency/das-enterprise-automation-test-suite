using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ChangeTradingNamePage : ChangeBasePage
    {
        protected override string PageTitle => $"Change trading name for {objectContext.GetProviderName()}";

        public ChangeTradingNamePage(ScenarioContext context) : base(context) { }
    }
}
