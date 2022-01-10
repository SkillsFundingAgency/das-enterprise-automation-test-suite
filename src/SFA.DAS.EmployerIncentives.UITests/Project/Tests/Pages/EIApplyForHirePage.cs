using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class EIApplyForHirePage : EIBasePage
    {
        protected override string PageTitle => "Apply for the hire a new apprentice payment";

        protected override By ContinueButton => By.LinkText("Start now");

        public EIApplyForHirePage(ScenarioContext context) : base(context) { }

        public QualificationQuestionPage ClickStartNowButtonInEIApplyPage()
        {
            Continue();
            return new QualificationQuestionPage(context);
        }
    }
}
