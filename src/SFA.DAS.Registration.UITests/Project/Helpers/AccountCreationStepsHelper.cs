using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class AccountCreationStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly RegistrationDataHelper _registrationDataHelper;
        private readonly RestartWebDriverHelper _restartWebDriverHelper;
        private readonly ObjectContext _objectContext;
        private readonly AccountSignOutHelper _accountSignOutHelper;

        public AccountCreationStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            _restartWebDriverHelper = new RestartWebDriverHelper(context);
            _accountSignOutHelper = new AccountSignOutHelper(context);
        }

        internal ConfirmYourIdentityPage RegisterUserAccount() => RegisterUserAccount(new CreateAnAccountToManageApprenticeshipsPage(_context), null);

        internal ConfirmYourIdentityPage RegisterUserAccount(CreateAnAccountToManageApprenticeshipsPage indexPage, string email) => indexPage.CreateAccount().Register(email);

        internal SelectYourOrganisationPage SearchForAnotherOrg(HomePage homepage, OrgType orgType)
        {
            return homepage.GoToYourOrganisationsAndAgreementsPage()
                .ClickAddNewOrganisationButton()
                .SearchForAnOrganisation(orgType);
        }

        internal CheckYourDetailsPage AddPayeDetailsForSingleOrgAornRoute(AddAPAYESchemePage addAPAYESchemePage) =>
            addAPAYESchemePage.AddAORN().EnterAornAndPayeDetailsForSingleOrgScenarioAndContinue();

        internal TheseDetailsAreAlreadyInUsePage ReEnterAornDetails(AddAPAYESchemePage addAPAYESchemePage) => addAPAYESchemePage.AddAORN().ReEnterTheSameAornDetailsAndContinue();

        internal CreateAnAccountToManageApprenticeshipsPage SignOut() => _accountSignOutHelper.SignOut();

        internal CheckYourDetailsPage SearchAndSelectOrg(SearchForYourOrganisationPage searchForYourOrganistionPage, OrgType org) =>
            searchForYourOrganistionPage.SearchForAnOrganisation(org).SelectYourOrganisation(org);

        internal SearchForYourOrganisationPage AddADifferentPaye(AddAPAYESchemePage addAPAYESchemePage) =>
            addAPAYESchemePage.AddPaye().ContinueToGGSignIn().SignInTo(1);

        internal AddAPAYESchemePage CreateAnotherUserAccount(CreateAnAccountToManageApprenticeshipsPage indexPage) => CreateUserAccount(indexPage, _registrationDataHelper.AnotherRandomEmail);

        internal HomePage CreateUserAccount() => AddNewAccount(RegisterUserAccount().ContinueToGetApprenticeshipFunding(), 0);

        internal AddAPAYESchemePage CreateUserAccount(CreateAnAccountToManageApprenticeshipsPage indexPage, string email) =>
            RegisterUserAccount(indexPage, email).ContinueToGetApprenticeshipFunding();

        internal HomePage AddAnotherPayeSchemeToTheAccount(HomePage homePage) =>
            homePage.GotoPAYESchemesPage()
                .ClickAddNewSchemeButton()
                .ContinueToGGSignIn()
                .EnterPayeDetailsAndContinue(1)
                .ClickContinueInConfirmPAYESchemePage()
                .SelectContinueAccountSetupInPAYESchemeAddedPage();

        internal PAYESchemesPage RemovePayeSchemeFromTheAccount(HomePage homePage) =>
            homePage.GotoPAYESchemesPage()
                .ClickNewlyAddedPayeDetailsLink()
                .ClickRemovePAYESchemeButton()
                .SelectYesRadioButtonAndContinue()
                .VerifyPayeSchemeRemovedInfoMessage();

        internal HomePage AddNewAccount(HomePage homePage, int index, OrgType orgType = OrgType.Default)
        {
            _objectContext.SetAdditionalAccount(GetOrgName(orgType), index);

            return AddNewAccount(homePage.GoToYourAccountsPage().AddNewAccount(), index, orgType);
        }

        internal HomePage AddNewAccount(AddAPAYESchemePage addAPAYESchemePage, int index, OrgType orgType = OrgType.Default)
        {
            return addAPAYESchemePage
                 .AddPaye()
                 .ContinueToGGSignIn()
                 .SignInTo(index)
                 .SearchForAnOrganisation(orgType)
                 .SelectYourOrganisation(orgType)
                 .ContinueToAboutYourAgreementPage()
                 .SelectViewAgreementNowAndContinue()
                 .SignAgreement()
                 .ClickOnViewYourAccountButton();
        }

        internal YouHaveAcceptedTheEmployerAgreementPage SignAgreementFromHomePage(HomePage homePage) =>
            homePage.ClickAcceptYourAgreementLinkInHomePagePanel().ClickContinueToYourAgreementButtonInAboutYourAgreementPage().SignAgreement();

        internal void UpdateOrganisationName(OrgType orgType) => _objectContext.UpdateOrganisationName(GetOrgName(orgType));

        internal void RelaunchApplication() => _restartWebDriverHelper.RestartWebDriver(UrlConfig.EmployerApprenticeshipService_BaseUrl, "EAS");

        private string GetOrgName(OrgType orgType)
        {
            return orgType switch
            {
                OrgType.Company => _registrationDataHelper.CompanyTypeOrg,
                OrgType.PublicSector => _registrationDataHelper.PublicSectorTypeOrg,
                _ => _registrationDataHelper.CharityTypeOrg1Name,
            };
        }
    }
}
