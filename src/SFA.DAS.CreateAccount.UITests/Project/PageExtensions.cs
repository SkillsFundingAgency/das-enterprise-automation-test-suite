using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Finance;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.PayeSchemes;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Settings;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.TeamMember;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Homepage;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Mailinator;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.Charity;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.PublicSectorOrganization;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project
{
    internal static class PageExtensions
    {
        internal static SiteHomepage SiteHomepage(this ScenarioContext context)
        {
            return new SiteHomepage(context);
        }

        internal static SignInPage SignInPage(this ScenarioContext context)
        {
            return new SignInPage(context);
        }

        internal static SetUpAsAUserPage SetUpAsAUserPage(this ScenarioContext context)
        {
            return new SetUpAsAUserPage(context);
        }

        internal static ConfirmYourIdentityPage ConfirmYourIdentityPage(this ScenarioContext context)
        {
            return new ConfirmYourIdentityPage(context);
        }

        internal static AccountSettingsPage AccountSettingsPage(this ScenarioContext context)
        {
            return new AccountSettingsPage(context);
        }

        internal static SignInGovernmentPage SignInGovernmentPage(this ScenarioContext context)
        {
            return new SignInGovernmentPage(context);
        }

        internal static WizardPage WizardPage(this ScenarioContext context)
        {
            return new WizardPage(context);
        }

        internal static SelectYourOrganisationPage SelectYourOrganisationPage(this ScenarioContext context)
        {
            return new SelectYourOrganisationPage(context);
        }

        internal static YourAccountsPage YourAccountsPage(this ScenarioContext context)
        {
            return new YourAccountsPage(context);
        }

        internal static EmployerAccountHomepage EmployerAccountHomepage(this ScenarioContext context)
        {
            return new EmployerAccountHomepage(context);
        }

        internal static YourTeamPage YourTeamPage(this ScenarioContext context)
        {
            return new YourTeamPage(context);
        }

        internal static CreateInvitationPage CreateInvitationPage(this ScenarioContext context)
        {
            return new CreateInvitationPage(context);
        }

        internal static ViewMemberPage ViewMemberPage(this ScenarioContext context)
        {
            return new ViewMemberPage(context);
        }

        internal static PayeSchemePage PayeSchemePage(this ScenarioContext context)
        {
            return new PayeSchemePage(context);
        }

        internal static ChangeEmailPage ChangeEmailPage(this ScenarioContext context)
        {
            return new ChangeEmailPage(context);
        }

        internal static ConfirmUpdatedEmailPage ConfirmUpdatedEmailPage(this ScenarioContext context)
        {
            return new ConfirmUpdatedEmailPage(context);
        }

        internal static ChangePasswordPage ChangePasswordPage(this ScenarioContext context)
        {
            return new ChangePasswordPage(context);
        }

        internal static ForgottenCredentialsPage ForgottenCredentialsPage(this ScenarioContext context)
        {
            return new ForgottenCredentialsPage(context);
        }

        internal static ResetCodeAndPassPage ResetCodeAndPassPage(this ScenarioContext context)
        {
            return new ResetCodeAndPassPage(context);
        }

        internal static GrantAuthorityPage GrantAuthorityPage(this ScenarioContext context)
        {
            return new GrantAuthorityPage(context);
        }

        internal static UsingYourGovtGatewayDetailsPage UsingYourGovtGatewayDetailsPage(this ScenarioContext context)
        {
            return new UsingYourGovtGatewayDetailsPage(context);
        }

        internal static SearchForYourOrganisationPage SearchForYourOrganisationPage(this ScenarioContext context)
        {
            return new SearchForYourOrganisationPage(context);
        }

        internal static SummaryPayePage SummaryPayePage(this ScenarioContext context)
        {
            return new SummaryPayePage(context);
        }

        internal static RenameAccountPage RenameAccountPage(this ScenarioContext context)
        {
            return new RenameAccountPage(context);
        }

        internal static UnlockAccountPage UnlockAccountPage(this ScenarioContext context)
        {
            return new UnlockAccountPage(context);
        }

        internal static OrganizationAddressPage OrganizationAddressPage(this ScenarioContext context)
        {
            return new OrganizationAddressPage(context);
        }

        internal static YourOrganizationsBasePage YourOrganizationsBasePage(this ScenarioContext context)
        {
            return new YourOrganizationsBasePage(context);
        }

        internal static EnterOrganizationNamePage EnterOrganizationNamePage(this ScenarioContext context)
        {
            return new EnterOrganizationNamePage(context);
        }

        internal static FindOrganizationAddressPage FindOrganizationAddressPage(this ScenarioContext context)
        {
            return new FindOrganizationAddressPage(context);
        }

        internal static ConfirmCharityOrganizationDetailsPage ConfirmCharityOrganizationDetails(this ScenarioContext context)
        {
            return new ConfirmCharityOrganizationDetailsPage(context);
        }

        internal static AboutYourSfaAgreementPage AboutYourSfaAgreementPage(this ScenarioContext context)
        {
            return new AboutYourSfaAgreementPage(context);
        }

        internal static AcceptTheAgreementPage AcceptTheAgreementPage(this ScenarioContext context)
        {
            return new AcceptTheAgreementPage(context);
        }

        internal static OrganizationsAndAgreementsBasePage OrganizationsAndAgreementsBasePage(this ScenarioContext context)
        {
            return new OrganizationsAndAgreementsBasePage(context);
        }

        internal static ApprenticesBasePage BaseApprenticesPage(this ScenarioContext context)
        {
            return new ApprenticesBasePage(context);
        }

        internal static FinanceBasePage FinanceBasePage(this ScenarioContext context)
        {
            return new FinanceBasePage(context);
        }

        internal static TransactionBasePage TransactionBasePage(this ScenarioContext context)
        {
            return new TransactionBasePage(context);
        }

        internal static DownloadTransactionsPage DownloadTransactionsPage(this ScenarioContext context)
        {
            return new DownloadTransactionsPage(context);
        }

        internal static TransfersPage TransfersPage(this ScenarioContext context)
        {
            return new TransfersPage(context);
        }

        internal static RemoveOrganizationPage RemoveOrganizationPage(this ScenarioContext context)
        {
            return new RemoveOrganizationPage(context);
        }

        internal static FundingProjectionPage FundingProjectionPage(this ScenarioContext context)
        {
            return new FundingProjectionPage(context);
        }

        internal static YourESFAAgreementPage YourESFAAgreementPage(this ScenarioContext context)
        {
            return new YourESFAAgreementPage(context);
        }

        internal static RecruitmentPage RecruitmentPage(this ScenarioContext context)
        {
            return new RecruitmentPage(context);
        }

        internal static ReviewYourDetailsPage ReviewYourDetailsPage(this ScenarioContext context)
        {
            return new ReviewYourDetailsPage(context);
        }

        internal static DetailsUpdatedPage DetailsUpdatedPage(this ScenarioContext context)
        {
            return new DetailsUpdatedPage(context);
        }

        internal static NotificationSettingsPage NotificationSettingsPage(this ScenarioContext context)
        {
            return new NotificationSettingsPage(context);
        }

        internal static PaneTabsPage PaneTabsPage(this ScenarioContext context)
        {
            return new PaneTabsPage(context);
        }

        internal static ActivityPage ActivityPage(this ScenarioContext context)
        {
            return new ActivityPage(context);
        }

        internal static SignOutPage SignOutPage(this ScenarioContext context)
        {
            return new SignOutPage(context);
        }

        internal static MailinatorHomePage MailinatorHomePage(this ScenarioContext context)
        {
            return new MailinatorHomePage(context);
        }

        internal static MailinatorInboxPage MailinatorInboxPage(this ScenarioContext context)
        {
            return new MailinatorInboxPage(context);
        }

        internal static MailinatorEmailPage MailinatorEmailPage(this ScenarioContext context)
        {
            return new MailinatorEmailPage(context);
        }

        internal static TermsAndConditionsPage TermsAndConditionsPage(this ScenarioContext context)
        {
            return new TermsAndConditionsPage(context);
        }

        internal static CheckDetailsPage CheckDetailsPage(this ScenarioContext context)
        {
            return new CheckDetailsPage(context);
        }

        internal static RemoveOrganizationConfirmPage RemoveOrganizationConfirmPage(this ScenarioContext context)
        {
            return new RemoveOrganizationConfirmPage(context);
        }

        internal static GetApprenticeshipFundingPage GetApprenticeshipFundingPage(this ScenarioContext context)
        {
            return new GetApprenticeshipFundingPage(context);
        }

        internal static SkippyHomePage SkippyHomePage(this ScenarioContext context)
        {
            return new SkippyHomePage(context);
        }
    }
}