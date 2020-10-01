using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class QualificationQuestionPage : EIBasePage
    {
        protected override string PageTitle => "Have you taken on new apprentices who started their contract of employment between 1 August 2020 and 31 January 2021?";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public QualificationQuestionPage(ScenarioContext context) : base(context) => _context = context;

        public SelectTheApprentice SelectYesAndContinueForEligibleApprenticesScenario()
        {
            SelectYes();
            return new SelectTheApprentice(_context);
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
