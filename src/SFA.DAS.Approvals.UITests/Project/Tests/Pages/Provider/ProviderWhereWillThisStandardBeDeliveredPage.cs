using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderWhereWillThisStandardBeDeliveredPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Where will this standard be delivered?";
        private By AtAnEmployerLocationRadiobutton => By.Id("EmployerLocationOption");

        public ProviderWhereWillThisStandardBeDeliveredPage(ScenarioContext context) : base(context) { }

        public ProviderAnyWhereInEnglandpage SelectOptionAtEmployerLocation()
        {
            javaScriptHelper.ClickElement(AtAnEmployerLocationRadiobutton);
            Continue();
            return new ProviderAnyWhereInEnglandpage(context);
        }
    }
}
