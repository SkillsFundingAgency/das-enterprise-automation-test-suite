using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class QualificationQuestionPage : EIBasePage
    {
        protected override string PageTitle => "Do you have apprentices who are eligible for the payment?";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public QualificationQuestionPage(ScenarioContext context) : base(context) => _context = context;

        public SelectTheApprenticesPage SelectYesAndContinueForEligibleApprenticesScenario()
        {
            SelectYes();
            return new SelectTheApprenticesPage(_context);
        }

        public SelectApprenticesShutterPage SelectYesAndContinueForNoEligibleApprenticesScenario()
        {
            SelectYes();
            return new SelectApprenticesShutterPage(_context);
        }

        public EmployerAgreementShutterPage SelectYesAndContinueForUnSignedAgreementScenario()
        {
            SelectYes();
            return new EmployerAgreementShutterPage(_context);
        }

        public QualificationQuestionShutterPage SelectNoAndContinue()
        {
            SelectNo();
            return new QualificationQuestionShutterPage(_context);
        }

        private void SelectYes()
        {
            SelectRadioOptionByForAttribute("HasTakenOnNewApprentices");
            Continue();
        }

        private void SelectNo()
        {
            SelectRadioOptionByForAttribute("HasTakenOnNewApprentices-2");
            Continue();
        }
    }
}
