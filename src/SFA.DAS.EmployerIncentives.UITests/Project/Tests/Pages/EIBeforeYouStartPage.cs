using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class EIBeforeYouStartPage : EIBasePage
    {
        protected override string PageTitle => "Before you start";

        protected override By ContinueButton => By.LinkText("Start now");

        public EIBeforeYouStartPage(ScenarioContext context) : base(context)  { }

        public EIApplyForHirePage ClickStartNowButtonInBeforeYouStartPage()
        {
            Continue();
            return new EIApplyForHirePage(context);
        }
    }
}
