using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    public class RAATableData
    {
        public string Location { get; set; }
        public string Anonymity { get; set; }
        public string DisabilityConfident { get; set; }
        public string ApplicationMethod { get; set; }
        public string ApprenticeshipType { get; set; }
        public string HoursPerWeek { get; set; }
        public string VacancyDuration { get; set; }
        public string NoOfPositions { get; set; }
        public string QualificationDetails { get; set; }
        public string WorkExperience { get; set; }
        public string TrainingCourse { get; set; }
        public string PostCode { get; set; }
    }

    [Binding]
    public class CommonSteps
    {
        private readonly RAAStepsHelper _raaStepsHelper;
        private readonly ManageStepsHelper _manageStepsHelper; 
        private readonly FAAStepsHelper _faaStepsHelper;
        private bool _exitFromWebsite;
        private bool _applyForVacancy;

        public CommonSteps(ScenarioContext context)
        {
            _raaStepsHelper = new RAAStepsHelper(context);
            _manageStepsHelper = new ManageStepsHelper(context);
            _faaStepsHelper = new FAAStepsHelper(context);
            _exitFromWebsite = true;
            _applyForVacancy = true;
        }


        [Given(@"the traineeship vacancy is Live in Recruit")]
        public void GivenTheTraineeshipVacancyIsLiveInRecruit(Table table)
        {
            AddTraineeshipVacancy(table.CreateInstance<RAATableData>());
        }

        [Given(@"the traineeship vacancy is Live in Recruit near '(.*)'")]
        public void GivenTheTraineeshipVacancyIsLiveInRecruitNear(string postCode)
        {
            AddTraineeshipVacancy(TestData(postCode));
        }

        [Given(@"the apprenticeship vacancy is Live in Recruit")]
        public void GivenTheApprenticeshipVacancyIsLiveInRecruit(Table table)
        {
            AddApprenticeshipVacancy(table.CreateInstance<RAATableData>());
        }

        [Given(@"the apprenticeship vacancy is Live in Recruit with no application")]
        public void GivenTheApprenticeshipVacancyIsLiveInRecruitWithNoApplication()
        {
            _applyForVacancy = false;
            AddApprenticeshipVacancy();
            _applyForVacancy = true;
        }


        [Given(@"the apprenticeship vacancy is Live in Recruit with an application")]
        public void GivenTheApprenticeshipVacancyIsLiveInRecruitWithAnApplication()
        {
            AddApprenticeshipVacancy();
        }

        [Given(@"the apprenticeship vacancy is Live in Recruit near '(.*)'")]
        public void GivenTheApprenticeshipVacancyIsLiveInRecruitNear(string postCode)
        {
            AddApprenticeshipVacancy(TestData(postCode));
        }

        private RAATableData TestData(string postCode)
        {
            return new RAATableData
            {
                Anonymity = "Yes",
                ApplicationMethod = "Online",
                ApprenticeshipType = "Standard",
                DisabilityConfident = "Yes",
                HoursPerWeek = "42",
                Location = "Add different location",
                NoOfPositions = "2",
                PostCode = postCode,
                QualificationDetails = "No",
                TrainingCourse = "No",
                VacancyDuration = "52",
                WorkExperience = "No"
            };
        }

        private void AddTraineeshipVacancy(RAATableData dataset)
        {
            string postCode = PostCodeTestData(dataset);

            var employerSelection = _raaStepsHelper.CreateANewVacancy();

            var raaEmployerInformation = _raaStepsHelper.ChoosesTheEmployer(employerSelection, dataset.Location, "2");

            _raaStepsHelper.ChooseAnonymous(raaEmployerInformation, "Yes");

            _raaStepsHelper.ProviderFillsOutTraineeshipDetails(dataset.Location, "Yes", "Online", postCode);

            VacancyIsLiveInRecruit(dataset);
        }

        private void AddApprenticeshipVacancy()
        {
            _exitFromWebsite = false;
            AddApprenticeshipVacancy(TestData("CV3 5JJ"));
            _exitFromWebsite = true;
        }

        private void AddApprenticeshipVacancy(RAATableData dataset)
        {
            string postCode = PostCodeTestData(dataset);

            var raa_employerSelection = _raaStepsHelper.CreateANewVacancy();

            var raa_EmployerInformation = _raaStepsHelper.ChoosesTheEmployer(raa_employerSelection, dataset.Location, dataset.NoOfPositions);

            _raaStepsHelper.ChooseAnonymous(raa_EmployerInformation, dataset.Anonymity);

            _raaStepsHelper.ProviderFillsOutApprenticeshipDetails(dataset.Location, dataset.DisabilityConfident, dataset.ApplicationMethod, dataset.ApprenticeshipType, dataset.HoursPerWeek, dataset.VacancyDuration, "National Minimum Wage for apprentices", postCode);

            VacancyIsLiveInRecruit(dataset);
        }

        private void VacancyIsLiveInRecruit(RAATableData dataset)
        {
            _raaStepsHelper.ApproveVacanacy().ExitFromWebsite();

            _manageStepsHelper.ApproveAVacancy(true);

            if (_applyForVacancy)
            {
                var faa_applicationFormPage = _faaStepsHelper.ApplyForVacancy();

                _faaStepsHelper.ConfirmApplicationSubmission(faa_applicationFormPage, dataset.QualificationDetails, dataset.WorkExperience, dataset.TrainingCourse);
            }

            var raa_homePage = _raaStepsHelper.GoToRAAHomePage(true);
            
            if (_applyForVacancy)
            {
                raa_homePage.SearchLiveVacancy();
            }
            else
            {
                raa_homePage.SearchLiveVacancyWithNoApplications();
            }
            
            if (_exitFromWebsite)
            {
                raa_homePage.ExitFromWebsite();
            }
        }

        private string PostCodeTestData(RAATableData dataset)
        {
            return string.IsNullOrEmpty(dataset.PostCode) ? "CV1 2WT" : dataset.PostCode;
        }
    }
}

