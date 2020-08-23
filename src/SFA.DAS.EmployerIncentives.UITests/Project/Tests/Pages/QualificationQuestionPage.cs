using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class QualificationQuestionPage : EIBasePage
    {
        protected override string PageTitle => "Have you taken on new apprentices that joined your payroll after 1 August 2020?";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public QualificationQuestionPage(ScenarioContext context) : base(context) => _context = context;

        public SelectApprenticesShutterPage SelectYesAndContinueForNoEligibleApprenticesScenario()
        {
            SelectRadioOptionByForAttribute("HasTakenOnNewApprentices");
            formCompletionHelper.Click(ContinueButton);
            return new SelectApprenticesShutterPage(_context);
        }

        public EmployerAgreementShutterPage SelectYesAndContinueForUnSignedAgreementScenario()
        {
            SelectRadioOptionByForAttribute("HasTakenOnNewApprentices");
            formCompletionHelper.Click(ContinueButton);
            return new EmployerAgreementShutterPage(_context);
        }

        public QualificationQuestionShutterPage SelectNoAndContinue()
        {
            SelectRadioOptionByForAttribute("HasTakenOnNewApprentices-2");
            formCompletionHelper.Click(ContinueButton);
            return new QualificationQuestionShutterPage(_context);
        }
    }
}
