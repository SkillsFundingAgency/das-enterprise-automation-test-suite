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

        public FAA_ApplicationForm ApplyForVacancy(FAA_HomePage homePage)
        {
            if (_objectContext.IsApprenticeshipVacancyType())
            {
                return homePage.FindAnApprenticeship()
                        .SearchByReferenceNumber()
                        .Apply();
            }
            else
            {
                return homePage.FindTraineeship()
                        .SearchByReferenceNumber()
                        .Apply();
            }   
        }

        public void ConfirmApplicationSubmission(FAA_ApplicationForm applicationFormPage, string qualificationdetails, string workExperience, string trainingCourse)
        {
            
            if (_objectContext.IsApprenticeshipVacancyType())
            {
                applicationFormPage.EnterEducation();
                applicationFormPage.EnterStartedYear();
                applicationFormPage.EnterFinishedYear();
                applicationFormPage.EnterQualificationdetails(qualificationdetails);
                applicationFormPage.EnterWorkExperience(workExperience);
                applicationFormPage.EnterTrainingCourse(trainingCourse);
                applicationFormPage.AnswerAdditionalQuestions();
                applicationFormPage.ClickSaveAndContinue();
                applicationFormPage.SelectAcceptSubmit();
                applicationFormPage.SubmitApprenticeshipApplication();
            }
            else
            {
                applicationFormPage.EnterWorkExperience(workExperience);
                applicationFormPage.EnterTrainingCourse(trainingCourse);
                applicationFormPage.EnterQualificationdetails(qualificationdetails);
                applicationFormPage.AnswerAdditionalQuestions();
                applicationFormPage.SubmitTraineeshipApplication();
            }
        }
    }
}
