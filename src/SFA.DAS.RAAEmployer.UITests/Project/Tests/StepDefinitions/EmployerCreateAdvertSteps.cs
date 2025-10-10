using SFA.DAS.RAA.Service.Project.Helpers;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using SFA.DAS.RAAEmployer.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAEmployer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerCreateAdvertSteps(ScenarioContext context)
    {
        private readonly EmployerCreateAdvertStepsHelper _employerCreateVacancyStepsHelper = new(context);

        private CreateAnApprenticeshipAdvertOrVacancyPage _createAnApprenticeshipAdvertPage;

        [Given(@"the Employer can create an advert by entering all the Optional fields")]
        public void TheEmployerCanCreateAnAdvertByEnteringAllTheOptionalFields()
        {
            _employerCreateVacancyStepsHelper.optionalFields = true;

            _employerCreateVacancyStepsHelper.CreateANewAdvert(RAAConst.Anonymous);
        }

        [When(@"the Employer creates first submitted advert")]
        public void TheEmployerCreatesFirstSubmittedAdvert() => _employerCreateVacancyStepsHelper.CreateFirstAdvertAndSubmit(_createAnApprenticeshipAdvertPage);

        [Given(@"the employer continue to add advert in the Recruitment")]
        public void TheEmployerContinueToAddAdvertInTheRecruitment() => _createAnApprenticeshipAdvertPage = _employerCreateVacancyStepsHelper.AddAnAdvert();

        [When(@"Employer selects '(National Minimum Wage|National Minimum Wage For Apprentices|Fixed Wage Type|Set As Competitive)' in the first part of the journey")]
        public void EmployerSelectsInTheFirstPartOfTheJourney(string wageType) => _employerCreateVacancyStepsHelper.CreateANewAdvert_WageType(wageType);

        [Given(@"the Employer creates an offline advert with disability confidence")]
        public void TheEmployerCreatesAnOfflineAdvertWithDisabilityConfidence() => _employerCreateVacancyStepsHelper.CreateOfflineVacancy();

        [Given(@"the Employer clones and creates an advert")]
        public void TheEmployerClonesAndCreatesAnAdvert() => _employerCreateVacancyStepsHelper.CloneAnAdvert();

        [Given(@"the Employer creates an advert by selecting different work location")]
        public void TheEmployerCreatesAnAdvertBySelectingDifferentWorkLocation() => _employerCreateVacancyStepsHelper.CreateANewAdvert(RAAConst.LegalEntityName, "different");

        [Given(@"the Employer creates an anonymous advert")]
        public void TheEmployerCreatesAnAnonymousAdvert() => _employerCreateVacancyStepsHelper.CreateANewAdvert(RAAConst.Anonymous);

        [Given(@"the Employer creates an advert by using a registered name")]
        public void TheEmployerCreatesAnanAdvertByUsingARegisteredName() => _employerCreateVacancyStepsHelper.CreateANewAdvert();

        [Given(@"the Employer creates a foundation advert by using a registered name")]
        public void TheEmployerCreatesAfoundationAdvertByUsingARegisteredName()
        {
            context["isFoundationAdvert"] = true;
            _employerCreateVacancyStepsHelper.CreateANewAdvert();
        }

        [Given(@"the Employer creates an advert by using a trading name")]
        public void TheEmployerCreatesAnAdvertByUsingATradingName() => _employerCreateVacancyStepsHelper.CreateANewAdvert(RAAConst.ExistingTradingName);

        [Given(@"the Employer creates a foundation advert by using a trading name")]
        public void TheEmployerCreatesAFoundationAdvertByUsingATradingName()
        {
            context["isFoundationAdvert"] = true;
            _employerCreateVacancyStepsHelper.CreateANewAdvert(RAAConst.ExistingTradingName);
        }

        [Given(@"the Employer creates an advert with ""(.*)"" work location")]
        public void GivenTheEmployerCreatesAnAdvertWithWorkLocation(string locationType) => _employerCreateVacancyStepsHelper.CreateANewAdvert(locationType, locationType);

        [Given(@"the Employer creates an advert with ""(.*)"" work location and '(.*)' wage type")]
        public void GivenTheEmployerCreatesAnAdvertWithWorkLocationAndWageType(string locationType, string wageType) => _employerCreateVacancyStepsHelper.CreateANewAdvert_LocationAndWageType(locationType, wageType);

    }
}
