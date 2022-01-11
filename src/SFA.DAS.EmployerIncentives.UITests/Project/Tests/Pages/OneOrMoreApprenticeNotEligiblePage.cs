using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class OneOrMoreApprenticeNotEligiblePage : EIBasePage
    {
        protected override string PageTitle => "One or more apprentices are not eligible for the payment";

        private By CancelApplication => By.LinkText("Cancel application");

        private By ContinueApplication => By.LinkText("Continue");

        public OneOrMoreApprenticeNotEligiblePage(ScenarioContext context) : base(context)  { }

        public EIHubPage CancelTheApplication()
        {
            formCompletionHelper.ClickElement(CancelApplication);

            return new EIHubPage(context);
        }

        public ConfirmApprenticesPage ContinueTheApplication()
        {
            formCompletionHelper.ClickElement(ContinueApplication);

            return new ConfirmApprenticesPage(context);
        }
    }
}
