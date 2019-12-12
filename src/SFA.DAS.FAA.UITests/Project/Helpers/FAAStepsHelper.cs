using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Helpers
{
    public class FAAStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly FAAConfig _config;
        private readonly RestartWebDriverHelper _helper;
        private readonly TabHelper _tabHelper;
        private readonly ObjectContext _objectContext;
        private const string _applicationName = "FindApprenticeship";

        public FAAStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetFAAConfig<FAAConfig>();
            _tabHelper = context.Get<TabHelper>();
            _helper = new RestartWebDriverHelper(context);
        }

        public string GetApplicationStatus()
        {
            return OpenFAAHomePageinNewtab()
                .FindAnApprenticeship()
                .SearchByReferenceNumber()
                .View()
                .ApplicationStatus();
        }

        public FAA_ApprenticeSearchPage FindAnApprenticeship() => GoToFAAHomePage().FindAnApprenticeship();

        public FAA_TraineeshipSearchPage FindATraineeship() => GoToFAAHomePage().FindATraineeship();
        

        public FAA_MyApplicationsHomePage GoToFAAHomePage()
        {
            if (_objectContext.IsFAARestart())
            {
                _helper.RestartWebDriver(_config.FAABaseUrl, _applicationName);
            }
            else
            {
                _tabHelper.OpenInNewtab(_config.FAABaseUrl);
            }

            return new FAA_Indexpage(_context)
                .GoToSignInPage()
                .SubmitValidLoginDetails();
        }

        public FAA_CreateAnAccountPage StartFAAAccountCreation()
        {
            _tabHelper.GoToUrl(_config.FAABaseUrl);

            return new FAA_Indexpage(_context)
                .GoToSignInPage()
                .ClickCreateAnAccountLink();
        }

        public void CreateFAAAccount(FAA_CreateAnAccountPage accountCreationPage)
        {
            accountCreationPage.SubmitAccountCreationDetails();
        }

        public void WithdrawVacancy()
        {
            SearchByReferenceNumber()
                .View()
                .Withdraw()
                .YesWithdraw();
        }

        public void ApplyForAVacancy(string qualificationdetails, string workExperience, string trainingCourse)
        {
            var applicationFormPage = SearchByReferenceNumber().Apply();

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

        private FAA_ApprenticeSummaryPage SearchByReferenceNumber()
        {
            if (_objectContext.IsApprenticeshipVacancyType())
            {
                return FindAnApprenticeship().SearchByReferenceNumber();
            }
            else
            {
                return FindATraineeship().SearchByReferenceNumber();
            }
        }
        private FAA_MyApplicationsHomePage OpenFAAHomePageinNewtab()
        {
            _tabHelper.OpenInNewtab(_config.FAABaseUrl);

            return new FAA_FindAnApprenticeshipHomePage(_context)
                .MyApplications();
        }
    }
}