using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System.Runtime.InteropServices.WindowsRuntime;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.Apprentice
{
    public class Apprentice_CheckYourAnswersPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "Check your answers";

        private By ApprenticehipTraining => By.XPath("(//dd[@class='govuk-summary-list__value'])[9]");
        private By Employer => By.XPath("(//dd[@class='govuk-summary-list__value'])[10]");
        private By TrainingProvider => By.XPath("(//dd[@class='govuk-summary-list__value'])[12]");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public Apprentice_CheckYourAnswersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApprenticeConfirmationPage ConfirmApprenticeAnswers()
        {
            Continue();
            return new ApprenticeConfirmationPage(_context);
        }
        public ApprenticeDetailsPage ClickChangeYourDetailsLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("Change your details"));
            return new ApprenticeDetailsPage(_context);
        }
        public ApprenticeDetailsPage ClickChangeYourLocationLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("Change your location"));
            return new ApprenticeDetailsPage(_context);
        }
        public ApprenticeDetailsPage ClickChangePreviousApprenticeShipLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("Change previous apprenticeship"));
            return new ApprenticeDetailsPage(_context);
        }
        public ApprenticeDetailsPage ClickChangeApprenticeshipsYouAreInterestedLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("Change apprenticeships you're interested in"));
            return new ApprenticeDetailsPage(_context);
        }
        public ApprenticeDetailsPage ClickChangeEthnicGroupLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("Change ethnicity"));
            return new ApprenticeDetailsPage(_context);
        }
        public ApprenticeDetailsPage ClickChangeGenderLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("Change gender"));
            return new ApprenticeDetailsPage(_context);
        }
        public Apprentice_CheckYourAnswersPage VerifyUpdatedPreviousApprenticeshipTrainingDetails(string apprenticeshipTraining)
        {
            pageInteractionHelper.VerifyText(ApprenticehipTraining, apprenticeshipTraining);
            return new Apprentice_CheckYourAnswersPage(_context);
        }
        public Apprentice_CheckYourAnswersPage VerifyUpdatedPreviousApprenticeshipEmployerDetails(string employer)
        {
            pageInteractionHelper.VerifyText(Employer, employer);
            return new Apprentice_CheckYourAnswersPage(_context);
        }
        public Apprentice_CheckYourAnswersPage VerifyUpdatedPreviousApprenticeshipTrainingProviderDetails(string trainingProvider)
        {
            pageInteractionHelper.VerifyText(TrainingProvider, trainingProvider);
            return new Apprentice_CheckYourAnswersPage(_context);
        }
    }
}
