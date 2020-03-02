using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.RAA.DataGenerator;

namespace SFA.DAS.FAA.UITests.Project.Helpers
{
    public class FAAStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly FAAConfig _config;
        private readonly RestartWebDriverHelper _helper;
        private readonly TabHelper _tabHelper;
        private readonly FAADataHelper _faaDataHelper;
        private readonly ObjectContext _objectContext;
        private const string _applicationName = "FindApprenticeship";           
        
        public FAAStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetFAAConfig<FAAConfig>();
            _tabHelper = context.Get<TabHelper>();
            _faaDataHelper = context.Get<FAADataHelper>();
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
                _tabHelper.OpenInNewTab(_config.FAABaseUrl);
            }

            var (username, password, _, _) = _objectContext.GetFAANewAccount();

                return new FAA_Indexpage(_context)
                   .GoToSignInPage()
                   .SubmitValidLoginDetails(username, password);
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
            accountCreationPage.SubmitAccountCreationDetails()
                .EnterActivationCode()
                .ClickSaveAndContinue()
                .VerifyPhoneNumberVerificationText()
                .EnterVerificationCode()
                .VerifySuccessfulVerificationText();            
        }

        public void CreateFAAAccountWithNoActivation(FAA_CreateAnAccountPage accountCreationPage)
        {
            var (username, password, _, _) = _objectContext.GetFAANewAccount();
            accountCreationPage.SubmitAccountCreationDetails()
                .ClickSignOut()
                .SubmitUnactivatedLoginDetails(username,password);
        }
                  
        public void WithdrawVacancy()
        {
            SearchByReferenceNumber()
                .View()
                .Withdraw()
                .YesWithdraw();
        }

        public void DismissNotification(string status)
        {
            switch(status)
            {
                case "Successful":
                    GoToFAAHomePage().DismissSuccessfulNotification();
                    break;

                case "Unsccessful":
                    GoToFAAHomePage().DismissUnsuccessfulNotification().ReadFeedback().VerifyReadFeedbackText();
                    break;
            }
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
                applicationFormPage.EnterStrengths();
                applicationFormPage.EnterSkills();
                applicationFormPage.EnterHobbiesAndInterests();
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
            _tabHelper.OpenInNewTab(_config.FAABaseUrl);

            return new FAA_FindAnApprenticeshipHomePage(_context)
                .MyApplications();
        }

        public void ChangePersonalSettings(string changingField)
        {
            if (changingField == "EmailId")
            {
                GoToSettingsPage().ChangeTheEmailIdSettings().ChangeEmailAddress().ConfirmEmailAddressUpdate();
            }
            else
            {
                GoToSettingsPage().ChangePhoneNumberSettings().EnterVerificationCode().VerifySuccessfulVerificationText();
            }
        }
        private FAA_SettingsPage GoToSettingsPage() => GoToFAAHomePage().GoToSettings();

        public FAA_TraineeshipSearchPage VerifyNoPostCodeErrorMessage(string location)
        {
            return FindATraineeship().VerifyNoPostcodeErrorMessage(location);
        }

        public FAA_TraineeshipSearchPage VerifyPartialPostCodeErrorMessage(string location)
        {
            return FindATraineeship().VerifyPartialPostcodeErrorMessage(location);
        }
    }
}