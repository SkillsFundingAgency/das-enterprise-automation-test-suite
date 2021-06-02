using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeHomePage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "My apprenticeship";
        private string YourEmployerLinkText => "Your employer";
        private string YourProviderLinkText => "Your training provider";
        private string YourApprenticeshipDetailsLinkText => "Your Apprenticeship Details";
        private string HowYourApprenticeshipWillBeDeliveredLinkText => "How your apprenticeship will be delivered";
        private string RolesAndResponsibilitiesLinkText => "Roles and responsibilities";
        private By SectionStatus(string sectionName) => By.XPath($"//h3[contains(text(),'{sectionName}')]/following-sibling::strong");
        private By AppreticeshipConfirmBannerHeader => By.XPath("//h2[@class='govuk-heading-m'][text()='Your apprenticeship is ready to confirm']");
        private By AppreticeshipConfirmBannerText => By.XPath("//div[contains(@class,'app-notification-banner')]/div");
        private By ConfirmYourApprenticeshipButton => By.XPath("//button[text()='Confirm your apprenticeship']");
        private By HelpAndSupportSection => By.XPath("//h2[text()='Help and Support']");
        private By HelpAndSupportLink => By.LinkText("help and support section");
        private string SignOutLinkText => "Sign out";

        public ApprenticeHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage(HeaderText, $"Welcome, {objectContext.GetFirstName()} {objectContext.GetLastName()}");
            VerifyPage(HelpAndSupportSection);
        }

        public ConfirmYourEmployerPage ConfirmYourEmployer()
        {
            formCompletionHelper.ClickLinkByText(YourEmployerLinkText);
            return new ConfirmYourEmployerPage(_context);
        }

        public AlreadyConfirmedEmployerPage ConfirmAlreadyConfirmedEmployer()
        {
            formCompletionHelper.ClickLinkByText(YourEmployerLinkText);
            return new AlreadyConfirmedEmployerPage(_context);
        }

        public ConfirmYourTrainingProviderPage ConfirmYourTrainingProvider()
        {
            formCompletionHelper.ClickLinkByText(YourProviderLinkText);
            return new ConfirmYourTrainingProviderPage(_context);
        }

        public AlreadyConfirmedTrainingProviderPage ConfirmAlreadyConfirmedTrainingProvider()
        {
            formCompletionHelper.ClickLinkByText(YourProviderLinkText);
            return new AlreadyConfirmedTrainingProviderPage(_context);
        }

        public ConfirmYourApprenticeshipDetailsPage ConfirmYourApprenticeshipDetails()
        {
            formCompletionHelper.ClickLinkByText(YourApprenticeshipDetailsLinkText);
            return new ConfirmYourApprenticeshipDetailsPage(_context);
        }

        public AlreadyConfirmedApprenticeshipDetailsPage ConfirmAlreadyConfirmedApprenticeship()
        {
            formCompletionHelper.ClickLinkByText(YourApprenticeshipDetailsLinkText);
            return new AlreadyConfirmedApprenticeshipDetailsPage(_context);
        }

        public ConfirmRolesAndResponsibilitiesPage ConfirmRolesAndResponsibilities()
        {
            formCompletionHelper.ClickLinkByText(RolesAndResponsibilitiesLinkText);
            return new ConfirmRolesAndResponsibilitiesPage(_context);
        }

        public AlreadyConfirmedRolesAndResponsibilitiesPage ConfirmAlreadyConfirmedRolesAndResponsibilities()
        {
            formCompletionHelper.ClickLinkByText(RolesAndResponsibilitiesLinkText);
            return new AlreadyConfirmedRolesAndResponsibilitiesPage(_context);
        }

        public ConfirmHowYourApprenticeshipWillBeDeliveredPage ConfirmHowYourApprenticeshipWillBeDelivered()
        {
            formCompletionHelper.ClickLinkByText(HowYourApprenticeshipWillBeDeliveredLinkText);
            return new ConfirmHowYourApprenticeshipWillBeDeliveredPage(_context);
        }

        public AlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage ConfirmAlreadyConfirmedHowYourApprenticeshipWillBeDelivered()
        {
            formCompletionHelper.ClickLinkByText(HowYourApprenticeshipWillBeDeliveredLinkText);
            return new AlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage(_context);
        }

        public string GetTheSectionStatus(string sectionName) => pageInteractionHelper.GetText(SectionStatus(sectionName)).Replace("\r\n", " ");

        public SignedOutPage SignOutFromTheService()
        {
            formCompletionHelper.ClickLinkByText(SignOutLinkText);
            return new SignedOutPage(_context);
        }

        public TransactionCompletePage ConfirmYourApprenticeshipFromTheTopBanner()
        {
            VerifyPage(AppreticeshipConfirmBannerHeader);
            VerifyPage(AppreticeshipConfirmBannerText, "Your apprenticeship is now ready for you to check confirm");
            formCompletionHelper.Click(ConfirmYourApprenticeshipButton);
            return new TransactionCompletePage(_context);
        }

        public HelpAndSupportPage NavigateToHelpAndSupportPage()
        {
            formCompletionHelper.Click(HelpAndSupportLink);
            return new HelpAndSupportPage(_context);
        }
    }
}
