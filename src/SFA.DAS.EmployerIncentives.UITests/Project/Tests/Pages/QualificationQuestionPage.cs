using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class QualificationQuestionPage : EIBasePage
    {
        protected override string PageTitle => $"Eligible apprentices at {ObjectContextExtension.GetOrganisationName(objectContext)}";

        public QualificationQuestionPage(ScenarioContext context) : base(context)  { }

        public SelectTheApprenticesPage SelectYesAndContinueForEligibleApprenticesScenario()
        {
            SelectYes();
            return new SelectTheApprenticesPage(context);
        }

        public SelectApprenticesShutterPage SelectYesAndContinueForNoEligibleApprenticesScenario()
        {
            SelectYes();
            return new SelectApprenticesShutterPage(context);
        }

        public EmployerAgreementShutterPage SelectYesAndContinueForUnSignedAgreementScenario()
        {
            SelectYes();
            return new EmployerAgreementShutterPage(context);
        }

        public QualificationQuestionShutterPage SelectNoAndContinue()
        {
            SelectNo();
            return new QualificationQuestionShutterPage(context);
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
