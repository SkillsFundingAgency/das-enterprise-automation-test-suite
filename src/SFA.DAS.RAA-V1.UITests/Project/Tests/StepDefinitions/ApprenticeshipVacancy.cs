using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprenticeshipVacancy
    {
        private RAA_EmployerSelection _employerSelection;
        private RAA_EmployerInformation _raaEmployerInformation;
        private RAA_EnterTrainingDetails _enterTrainingDetails;
        private RAA_EnterFurtherDetails _enterFurtherDetails;
        private RAA_RequirementsAndProspects _requirementsAndProspects;
        private Manage_HomePage _manage_HomePage;
        private readonly RAAStepsHelper _raaStepsHelper;
        private readonly ManageStepsHelper _manageStepsHelper;

        public ApprenticeshipVacancy(ScenarioContext context)
        {
            _raaStepsHelper = new RAAStepsHelper(context);
            _manageStepsHelper = new ManageStepsHelper(context);
        }

        [When(@"the Reviewer initiates reviewing the Vacancy in Manage")]
        public void WhenTheReviewerInitiatesReviewingTheVacancyInManage()
        {
            _manage_HomePage = _manageStepsHelper.GoToManageHomePage();
        }

        [Then(@"the Reviewer is able to approve the Vacancy '(.*)','(.*)'")]
        public void ThenTheReviewerIsAbleToApproveTheVacancy(string changeTeam, string changeRole)
        {
            _manage_HomePage.ApproveAVacancy(changeTeam, changeRole);
        }

        [Given(@"the Provider initiates Create Apprenticeship Vacancy in Recruit")]
        public void GivenTheProviderInitiatesCreateApprenticeshipVacancyIn()
        {
            _employerSelection = _raaStepsHelper.CreateANewVacancy();
        }

        [When(@"the Provider chooses the employer '(.*)','(.*)'")]
        public void WhenTheProviderChoosesTheEmployer(string location, string noOfpositions)
        {
            _raaEmployerInformation = _employerSelection.SelectAnEmployer();
            
            switch (location)
            {
                case "Use the main employer address":
                    _raaEmployerInformation = _raaEmployerInformation.UseTheMainEmployerAddress(noOfpositions);
                    break;

                case "Add different location":
                    _raaEmployerInformation = _raaEmployerInformation.AddDifferentLocation();
                    break;
                case "Set as a nationwide vacancy":
                    _raaEmployerInformation = _raaEmployerInformation.SetAsANationWideVacancy(noOfpositions);
                    break;
            }
        }

        [When(@"the Provider chooses their '(.*)'")]
        public void WhenTheProviderChoosesTheir(string answer)
        {
            switch (answer)
            {
                case "Yes":
                    _raaEmployerInformation.EmployerDoesNotWantToBeAnonymous();
                    break;

                case "No":
                    _raaEmployerInformation.EmployerWishesToBeAnonymous();
                    break;
            }
        }

        [When(@"the Provider fills out details for an Offline Vacancy '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenTheProviderFillsOutDetailsForAnOfflineVacancy(string location, string disabilityConfident, string applicationMethod, string apprenticeShip, string hoursPerWeek, string vacancyDuration)
        {
            switch (location)
            {
                case "Use the main employer address":
                    break;

                case "Add different location":
                    _raaStepsHelper.AddMultipleVacancy();
                    break;

                case "Set as a nationwide vacancy":
                    hoursPerWeek = "37";
                    vacancyDuration = "52";
                    break;
            }
            _enterTrainingDetails = _raaStepsHelper.EnterBasicVacancyDetails(disabilityConfident, applicationMethod);

            _enterFurtherDetails = _raaStepsHelper.EnterTrainingDetails(_enterTrainingDetails, apprenticeShip);

            _requirementsAndProspects = _raaStepsHelper.EnterFurtherDetails(_enterFurtherDetails, hoursPerWeek, vacancyDuration);

            _raaStepsHelper.EnterRequirementsAndProspects(_requirementsAndProspects);

            if (applicationMethod != "Offline")
            {
                _raaStepsHelper.EnterExtraQuestions();
            }
        }

        [Then(@"Provider is able to submit the vacancy for approval")]
        public void ThenProviderIsAbleToSubmitTheVacancyForApproval()
        {
            _raaStepsHelper
                .ApproveVacanacy()
                .ExitFromWebsite();
        }
    }
}
