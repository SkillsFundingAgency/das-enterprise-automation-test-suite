using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderYourStandardsAndTrainingVenuesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Your standards and training venues";

        private static By StandardsYouDeliver => By.LinkText("The standards you deliver");

        public ProviderYourStandardsAndTrainingVenuesPage(ScenarioContext context) : base(context) { }

        public ProviderManageTheStandardsYouDeliverPage ClickOnTheStandardsYouDeliverLink()
        {
            formCompletionHelper.Click(StandardsYouDeliver);            
            return new ProviderManageTheStandardsYouDeliverPage(context);
        }

    }

}
