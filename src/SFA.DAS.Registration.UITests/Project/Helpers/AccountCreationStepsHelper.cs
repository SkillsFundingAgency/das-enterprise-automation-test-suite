using NUnit.Framework;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions;
using TechTalk.SpecFlow;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class AccountCreationStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly RegistrationDataHelper _registrationDataHelper;

        public AccountCreationStepsHelper(ScenarioContext context)
        {
            _context = context;
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
        }

        public ConfirmPage RegisterUserAccount() => new IndexPage(_context).CreateAccount().Register();

        public SelectYourOrganisationPage SearchForAnotherOrg(HomePage homepage, OrgType orgType)
        {
            return homepage.GoToYourOrganisationsAndAgreementsPage()
                .ClickAddNewOrganisationButton()
                .SearchForAnOrganisation(orgType);
        }

        public void AddLevyDeclarations() => new BackgroundDataSteps(_context).GivenLevyDeclarationsIsAddedForPastMonthsWithLevypermonthAs("5", "10000");

        public void AssertManuallyAddedAddressDetailsAndCompleteRegistration(CheckYourDetailsPage checkYourDetailsPage)
        {
            var manuallyEnteredAddress = $"{_registrationDataHelper.FirstLineAddressForManualEntry} " +
                                            $"{_registrationDataHelper.CityNameForManualEntry} " +
                                            $"{_registrationDataHelper.PostCodeForManualEntry}";
            Assert.AreEqual(manuallyEnteredAddress, checkYourDetailsPage.GetManuallyAddedOrganisationAddress());

            checkYourDetailsPage.ClickYesTheseDetailsAreCorrectButtonInCheckYourDetailsPage()
                        .SelectViewAgreementNowAndContinue()
                        .SignAgreement();
        }

        public CheckYourDetailsPage AddPayeDetailsForSingleOrgAornRoute(AddAPAYESchemePage addAPAYESchemePage) =>
            addAPAYESchemePage.AddAORN().EnterAornAndPayeDetailsForSingleOrgScenarioAndContinue();

        public TheseDetailsAreAlreadyInUsePage ReEnterAornDetails(AddAPAYESchemePage addAPAYESchemePage) => addAPAYESchemePage.AddAORN()
                .ReEnterTheSameAornDetailsAndContinue();
    }
}
