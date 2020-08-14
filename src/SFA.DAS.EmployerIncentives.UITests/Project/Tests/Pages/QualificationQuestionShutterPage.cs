using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class QualificationQuestionShutterPage : EIBasePage
    {
        protected override string PageTitle => "You can only apply for apprentices who started their contract of employment between 1 August 2020 and 31 January 2021";

        #region Locators
        private readonly ScenarioContext _context;
        private By ReturnToAccountHomeButton => By.LinkText("Return to account home");
        #endregion

        public QualificationQuestionShutterPage(ScenarioContext context) : base(context) => _context = context;

        public HomePage ClickOnReturnToAccountHomeLink()
        {
            formCompletionHelper.Click(ReturnToAccountHomeButton);
            return new HomePage(_context);
        }
    }
}
