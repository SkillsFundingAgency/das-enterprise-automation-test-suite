using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class OrganisationDetailsChangeSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RegistrationSqlDataHelper _registrationSqlDataHelper;
        private YourAgreementsWithTheEducationAndSkillsFundingAgencyPage _yourAgreementsWithTheEducationAndSkillsFundingAgencyPage;
        private ReviewYourDetailsPage _reviewYourDetailsPage;

        public OrganisationDetailsChangeSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _registrationSqlDataHelper = context.Get<RegistrationSqlDataHelper>();
        }

        [When(@"the Employer reviews Agreement page")]
        public void WhenTheEmployerReviewsAgreementPage() => _yourAgreementsWithTheEducationAndSkillsFundingAgencyPage = ClickViewAgreementLinkInYourOrganisationsAndAgreementsPage();

        [Then(@"clicking on 'Update these details' link displays 'Review your details' page showing (These details are the same as those previously held|We've retrieved the most up-to-date details we could find for your organisation)")]
        public void ThenClickingOnUpdateTheseDetailsLinkDisplaysReviewYourDetailsPageShowingExpectedMessage(string expectedMessage)
        {
            _reviewYourDetailsPage = _yourAgreementsWithTheEducationAndSkillsFundingAgencyPage.ClickUpdateTheseDetailsLinkInReviewYourDetailsPage()
                .VerifyInfoTextInReviewYourDetailsPage(expectedMessage);
        }

        [When(@"the Employer revisits the Agreement page during change in Organisation name scenario")]
        public void WhenTheEmployerRevisitsTheAgreementPageDuringChangeInOrganisationNameScenario()
        {
            var loginUser = _objectContext.GetLoginCredentials();
            _registrationSqlDataHelper.UpdateLegalEntityName(loginUser.Username);

            _yourAgreementsWithTheEducationAndSkillsFundingAgencyPage = ClickViewAgreementLinkInYourOrganisationsAndAgreementsPage();
        }

        [Then(@"continuing by choosing 'Update details' option displays 'Details updated' page showing (You've successfully updated your organisation details)")]
        public void ThenContinuingByChoosingOptionDisplaysPageShowing(string expectedMessage)
        {
            _reviewYourDetailsPage.SelectUpdateMyDetailsRadioOptionAndContinueInReviewYourDetailsPage()
                .SelectGoToHomePageOptionAndContinueInDetailsUpdatedPage();
        }

        private YourAgreementsWithTheEducationAndSkillsFundingAgencyPage ClickViewAgreementLinkInYourOrganisationsAndAgreementsPage()
        {
            new HomePage(_context, true).GoToYourOrganisationsAndAgreementsPage()
                .ClickViewAgreementLink();
            return new YourAgreementsWithTheEducationAndSkillsFundingAgencyPage(_context);
        }

        [Then(@"the 'Update these details' link is not displayed for PublicSector Type Org")]
        public void ThenTheUpdateTheseDetailsLinkIsNotDisplayedForPublicSectorTypeOrg() =>
            Assert.IsFalse(_yourAgreementsWithTheEducationAndSkillsFundingAgencyPage.VerifyIfUpdateTheseDetailsLinkIsPresent(), "'Update these details' link is present even though it should not be present for a PublicSector Type Org");
    }
}
