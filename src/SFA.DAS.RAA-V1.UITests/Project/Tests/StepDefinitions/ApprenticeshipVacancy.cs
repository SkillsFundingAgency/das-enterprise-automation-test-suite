using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprenticeshipVacancy
    {
        private readonly ScenarioContext _context;
        private RAA_EmployerSelection _employerSelection;
        private RAA_EmployerInformation _raaEmployerInformation;

        public ApprenticeshipVacancy(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"the Provider initiates Create Apprenticeship Vacancy in Recruit")]
        public void GivenTheProviderInitiatesCreateApprenticeshipVacancyIn()
        {
            _employerSelection = new RAAIndexPage(_context)
                .ClickOnSignInButton()
                .ClickRecruitStaffIdams()
                .SubmitValidLoginDetails()
                .CreateANewVacancy();
        }

        [When(@"the Provider chooses the employer '(.*)','(.*)'")]
        public void WhenTheProviderChoosesTheEmployer(string location, string noOfpositions)
        {
            _raaEmployerInformation = _employerSelection.SelectAndEmployer();
            
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

        [When(@"the Provider chooses their '([^']*)'")]
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


    }
}
