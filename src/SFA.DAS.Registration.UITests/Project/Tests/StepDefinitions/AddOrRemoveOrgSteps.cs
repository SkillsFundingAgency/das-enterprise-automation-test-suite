using NUnit.Framework;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AddOrRemoveOrgSteps
    {
        private readonly ScenarioContext _context;
        private readonly RegistrationDataHelper _registrationDataHelper;
        private readonly AccountCreationStepsHelper _accountCreationStepsHelper;
        private HomePage _homePage;
        private CheckYourDetailsPage _checkYourDetailsPage;
        private YourOrganisationsAndAgreementsPage _yourOrganisationsAndAgreementsPage;

        public AddOrRemoveOrgSteps(ScenarioContext context)
        {
            _context = context;
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            _accountCreationStepsHelper = new AccountCreationStepsHelper(context);
        }

        [Then(@"the Employer is Not allowed to Remove the first Org added")]
        public void ThenTheEmployerIsNotAllowedToRemoveTheFirstOrgAdded() =>
            Assert.AreEqual(new HomePage(_context).GoToYourOrganisationsAndAgreementsPage().IsRemoveLinkBesideNewlyAddedOrg(), false);

        [Given(@"the Employer initiates adding another Org of (Company|PublicSector|Charity|Charity2) Type")]
        [When(@"the Employer initiates adding another Org of (Company|PublicSector|Charity|Charity2) Type")]
        public void WhenTheEmployerInitiatesAddingAnotherOrgType(OrgType orgType)
        {
            _registrationDataHelper.SetAccountNameAsOrgName = false;
            _checkYourDetailsPage = _accountCreationStepsHelper.SearchForAnotherOrg(new HomePage(_context, true), orgType).SelectYourOrganisation(orgType);
        }

        [Then(@"the new Org added is shown in the Account Organisations list")]
        public void ThenTheNewOrgAddedIsShownInTheAccountOrganisationsList() => _yourOrganisationsAndAgreementsPage =
            _checkYourDetailsPage.ClickYesContinueButton().GoToYourOrganisationsAndAgreementsPage().VerifyNewlyAddedOrgIsPresent();

        [Then(@"the Employer is able check the details of the Charity Org added are displayed in the 'Check your details' page and Continue")]
        public void ThenTheEmployerIsAbleToCheckTheDetailsOfTheCharityOrgAddedAreDisplayedInThePageAndContinue()
        {
            VerifyOrgDetails(_registrationDataHelper.CharityTypeOrg1Number, _registrationDataHelper.CharityTypeOrg1Name, _registrationDataHelper.CharityTypeOrg1Address);
            ThenTheNewOrgAddedIsShownInTheAccountOrganisationsList();
        }

        [Then(@"the Employer is able check the details of the 2nd Charity Org added are displayed in the 'Check your details' page and Continue")]
        public void ThenTheEmployerIsAbleToCheckTheDetailsOfThe2ndCharityOrgAddedAreDisplayedInThePageAndContinue()
        {
            VerifyOrgDetails(_registrationDataHelper.CharityTypeOrg2Number, _registrationDataHelper.CharityTypeOrg2Name, _registrationDataHelper.CharityTypeOrg2Address);
            ThenTheNewOrgAddedIsShownInTheAccountOrganisationsList();
        }

        [Then(@"Employer is Allowed to remove the second Org added from the account")]
        public void ThenEmployerIsAllowedToRemoveTheSecondOrgAddedFromTheAccount() =>
            _yourOrganisationsAndAgreementsPage.ClickOnRemoveAnOrgFromYourAccountLink()
                .SelectYesRadioOptionAndClickContinueInRemoveOrganisationPage().VerifyOrgRemovedMessageInHeader();

        [When(@"the Employer adds another Org to the Account")]
        public void WhenTheEmployerAddsAnotherOrgToTheAccount() => AddOrgToTheAccount(OrgType.Company);

        [Then(@"the Sign Agreement journey from the Account home page shows Accepted Agreement page")]
        public void ThenTheSignAgreementJourneyFromTheAccountHomePageShowsAcceptedAgreementPage() =>
            SignAgreementFromHomePage().ClickOnViewYourAccountButton();

        [When(@"the Employer adds two additional Orgs to the Account")]
        public void WhenTheEmployerAddsTwoAdditionalOrgsToTheAccount()
        {
            AddOrgToTheAccount(OrgType.Company2);
            AddOrgToTheAccount(OrgType.Charity);
        }

        [Then(@"the Sign Agreement journey from the Account home page shows Accepted Agreement page with link to review other pending agreements")]
        public void ThenTheSignAgreementJourneyFromTheAccountHomePageShowsAcceptedAgreementPageWithLinkToReviewOtherPendingAgreements() =>
            SignAgreementFromHomePage().ClickOnReviewAndAcceptYourOtherAgreementsLink();

        private void VerifyOrgDetails(string orgNumber, string OrgName, string orgAddress)
        {
            Assert.AreEqual(orgNumber, _checkYourDetailsPage.GetOrganisationNumber());
            Assert.AreEqual(OrgName, _checkYourDetailsPage.GetOrganisationName());
            Assert.AreEqual(orgAddress, _checkYourDetailsPage.GetOrganisationAddress());
        }

        private void AddOrgToTheAccount(OrgType orgType)
        {
            WhenTheEmployerInitiatesAddingAnotherOrgType(orgType);
            _homePage = _checkYourDetailsPage.ClickYesContinueButton().GoToHomePage();
        }

        private YouHaveAcceptedTheEmployerAgreementPage SignAgreementFromHomePage() =>
            _homePage.ClickAcceptYourAgreementLinkInHomePagePanel().ClickContinueToYourAgreementButtonInAboutYourAgreementPage().SignAgreement();
    }
}
