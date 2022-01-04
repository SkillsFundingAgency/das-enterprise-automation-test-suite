using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class EIApplyPage : EIBasePage
    {
        protected override string PageTitle => "Apply for the hire a new apprentice payment";

        #region Locators
        private By StartNowButton => By.LinkText("Start now");
        #endregion

        public EIApplyPage(ScenarioContext context) : base(context)  { }

        public QualificationQuestionPage ClickStartNowButtonInEIApplyPage()
        {
            formCompletionHelper.Click(StartNowButton);
            return new QualificationQuestionPage(context);
        }
    }
}
