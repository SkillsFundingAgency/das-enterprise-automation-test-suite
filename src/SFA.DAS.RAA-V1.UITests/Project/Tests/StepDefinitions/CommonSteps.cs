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
        public string Changeteam { get; set; }
        public string ChangeRole { get; set; }
        public string NoOfPositions { get; set; }
        public string QualificationDetails { get; set; }
        public string WorkExperience { get; set; }
        public string TrainingCourse { get; set; }
    }

    [Binding]
    public class CommonSteps
    {
        private readonly RAAStepsHelper _raaStepsHelper;
        private readonly ManageStepsHelper _manageStepsHelper; 
        private readonly FAAStepsHelper _faaStepsHelper;

        public CommonSteps(ScenarioContext context)
        {
            _raaStepsHelper = new RAAStepsHelper(context);
            _manageStepsHelper = new ManageStepsHelper(context);
            _faaStepsHelper = new FAAStepsHelper(context);
        }


        [Given(@"the traineeship vacancy is Live in Recruit")]
        public void GivenTheTraineeshipVacancyIsLiveInRecruit(Table table)
        {
            var dataset = table.CreateInstance<RAATableData>();

            var employerSelection = _raaStepsHelper.CreateANewVacancy();

            var raaEmployerInformation = _raaStepsHelper.ChoosesTheEmployer(employerSelection, dataset.Location, "2");

            _raaStepsHelper.ChooseAnonymous(raaEmployerInformation, "Yes");

            _raaStepsHelper.ProviderFillsOutTraineeshipDetails(dataset.Location);

            VacancyIsLiveInRecruit(dataset);
        }

        [Given(@"the apprenticeship vacancy is Live in Recruit")]
        public void GivenTheApprenticeshipVacancyIsLiveInRecruit(Table table)
        {
            var dataset = table.CreateInstance<RAATableData>();

            var raa_employerSelection = _raaStepsHelper.CreateANewVacancy();

            var raa_EmployerInformation = _raaStepsHelper.ChoosesTheEmployer(raa_employerSelection, dataset.Location, dataset.NoOfPositions);

            _raaStepsHelper.ChooseAnonymous(raa_EmployerInformation, dataset.Anonymity);

            _raaStepsHelper.ProviderFillsOutDetails(dataset.Location, dataset.DisabilityConfident, dataset.ApplicationMethod, dataset.ApprenticeshipType, dataset.HoursPerWeek, dataset.VacancyDuration);

            VacancyIsLiveInRecruit(dataset);
        }

        private void VacancyIsLiveInRecruit(RAATableData dataset)
        {
            _raaStepsHelper.ApproveVacanacy().ExitFromWebsite();

            var manage_HomePage = _manageStepsHelper.GoToManageHomePage(true);

            manage_HomePage.ApproveAVacancy(dataset.Changeteam, dataset.ChangeRole);

            var faa_homePage = _faaStepsHelper.GoToFAAHomePage(true);

            var faa_applicationFormPage = _faaStepsHelper.ApplyForVacancy(faa_homePage);

            _faaStepsHelper.ConfirmApplicationSubmission(faa_applicationFormPage, dataset.QualificationDetails, dataset.WorkExperience, dataset.TrainingCourse);

            var raa_homePage = _raaStepsHelper.GoToRAAHomePage(true);

            raa_homePage.SearchLiveVacancy();

            raa_homePage.ExitFromWebsite();
        }
    }
}

