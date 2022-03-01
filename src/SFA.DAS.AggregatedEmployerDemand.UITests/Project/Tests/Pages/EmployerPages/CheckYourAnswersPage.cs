using OpenQA.Selenium;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages
{
    public class CheckYourAnswersPage : AedBasePage
    {
        protected override string PageTitle => "Check your answers";
        
        public CheckYourAnswersPage(ScenarioContext context) : base(context)  { }

        private By Confirm => By.CssSelector("#submit-demand");

        public EmailVerificationPage ConfirmYourAnswers()
        {
            formCompletionHelper.Click(Confirm);
            return new EmailVerificationPage(context);
        }
    }
}
