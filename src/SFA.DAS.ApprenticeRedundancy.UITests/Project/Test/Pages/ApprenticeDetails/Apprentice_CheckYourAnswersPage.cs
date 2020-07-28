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
        private By ChangeDetails => By.XPath("(//span[@class='govuk-visually-hidden'])[1]");
        private By YourLocation => By.XPath("//div[@class='das-check-section']//span[text()=' your location']");
        private By PreviousApprenticeship => By.XPath("//div[@class='das-check-section']//span[text()=' Previous apprenticeship']");
        private By Apprenticeships => By.XPath("(//span[@class='govuk-visually-hidden'])[4]");
        private By Ethnicity => By.XPath("//div[@class='das-check-section']//span[text()=' ethnicity']");
        private By Gender => By.XPath("//div[@class='das-check-section']//span[text()=' gender']");

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
            pageInteractionHelper.FocusTheElement(ChangeDetails);
            formCompletionHelper.ClickElement(ChangeDetails);
            return new ApprenticeDetailsPage(_context);
        }
        public ApprenticeDetailsPage ClickChangeYourLocationLink()
        {
            formCompletionHelper.ClickElement(YourLocation);
            return new ApprenticeDetailsPage(_context);
        }
        public ApprenticeDetailsPage ClickChangePreviousApprenticeShipLink()
        {
            formCompletionHelper.ClickElement(PreviousApprenticeship);
            return new ApprenticeDetailsPage(_context);
        }
        public ApprenticeDetailsPage ClickChangeApprenticeshipsYouAreInterestedLink()
        {
            formCompletionHelper.ClickElement(Apprenticeships);
            return new ApprenticeDetailsPage(_context);
        }
        public ApprenticeDetailsPage ClickChangeEthnicGroupLink()
        {
            formCompletionHelper.ClickElement(Ethnicity);
            return new ApprenticeDetailsPage(_context);
        }
        public ApprenticeDetailsPage ClickChangeGenderLink()
        {
            formCompletionHelper.ClickElement(Gender);
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
