using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Project.Helpers.CSSSelectors;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class CheckProviderIndexPage : CheckPageUsingShorterTimeOut
    {
        protected override string PageTitle { get; }

        protected override By Identifier => ProviderCSSSelectors.ProviderIndexStartSelector;

        public CheckProviderIndexPage(ScenarioContext context) : base(context) { }
    }
}
