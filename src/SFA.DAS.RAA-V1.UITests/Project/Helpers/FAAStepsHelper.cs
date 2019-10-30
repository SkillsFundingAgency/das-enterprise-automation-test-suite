using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class FAAStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly RAAV1Config _config;
        private readonly RestartWebDriverHelper _helper;
        private readonly ObjectContext _objectContext;
        private const string _applicationName = "FindApprenticeship";

        public FAAStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetRAAV1Config<RAAV1Config>();
            _helper = new RestartWebDriverHelper(context);
        }

        public FAA_HomePage GoToFAAHomePage()
        {
            _helper.RestartWebDriver(_config.FAABaseUrl, _applicationName);

            return new FAA_Indexpage(_context)
                .GoToSignInPage()
                .SubmitValidLoginDetails();
        }

        public FAA_ApplicationForm ApplyForApprenticeship(FAA_HomePage homePage)
        {
            return homePage.ClickFindAnApprenticeshipLink()
               .SearchByReferenceNumber()
               .ApplyForApprenticeship();
        }

        public void ConfirmApplicationSubmission(FAA_ApplicationForm applicationFormPage, string qualificationdetails, string workExperience, string trainingCourse)
        {
            applicationFormPage.EnterEducation();
            applicationFormPage.EnterStartedYear();
            applicationFormPage.EnterFinishedYear();
            applicationFormPage.EnterQualificationdetails(qualificationdetails);
            applicationFormPage.EnterWorkExperience(workExperience);
            applicationFormPage.EnterTrainingCourse(trainingCourse);
            applicationFormPage.AnswerQuestions();
            applicationFormPage.ClickSaveAndContinue();
            applicationFormPage.SelectAcceptSubmit();
            if (_objectContext.IsApprenticeshipVacancyType())
            {
                applicationFormPage.SubmitApprenticeshipApplication();
            }
            else
            {
                applicationFormPage.SubmitTraineeshipApplication();
            }
        }
    }
}
