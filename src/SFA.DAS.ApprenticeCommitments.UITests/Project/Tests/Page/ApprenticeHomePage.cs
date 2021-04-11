using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeHomePage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;
        private By HeaderText => By.CssSelector(".app-user-header__name");

        protected override string PageTitle => "My apprenticeship";
        private string YourEmployerLinkText => "Your employer";
        private string YourProviderLinkText => "Your training provider";
        private string YourApprenticeshipDetailsLinkText => "Your Apprenticeship Details";
        private By YourEmployerSectionStatus(string sectionName) => By.XPath($"//h3[contains(text(),'{sectionName}')]/following-sibling::strong");

        public ApprenticeHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage(HeaderText, $"Welcome, {objectContext.GetFirstName()} {objectContext.GetLastName()}");
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

        public ConfirmYourApprenticeshipDetailsPage ConfirmYourApprenticeship()
        {
            formCompletionHelper.ClickLinkByText(YourApprenticeshipDetailsLinkText);
            return new ConfirmYourApprenticeshipDetailsPage(_context);
        }

        public AlreadyConfirmedApprenticeshipDetailsPage ConfirmAlreadyConfirmedApprenticeship()
        {
            formCompletionHelper.ClickLinkByText(YourApprenticeshipDetailsLinkText);
            return new AlreadyConfirmedApprenticeshipDetailsPage(_context);
        }

        public ApprenticeHomePage VerifyTheSectionStatus(string sectionName, string expectedStatus)
        {
            VerifyPage(YourEmployerSectionStatus(sectionName), expectedStatus);
            return new ApprenticeHomePage(_context);
        }
    }
}
