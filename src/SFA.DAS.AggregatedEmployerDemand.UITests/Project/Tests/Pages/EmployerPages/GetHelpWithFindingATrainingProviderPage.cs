using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages
{
    public class GetHelpWithFindingATrainingProviderPage : AEDBasePage
    {
        protected override string PageTitle => "Get help with finding a training provider";
        private readonly ScenarioContext _context;

        #region Locators
        private By NumberOfApprenticesTextBox => By.Id("NumberOfApprentices");
        private By ApprenticeshipLocationTextBox => By.Id("search-location");
        private By OrganisationNameTextBox => By.Id("OrganisationName");
        private By OrganisationEmailAddressTextBox => By.Id("ContactEmailAddress");
        #endregion

        public GetHelpWithFindingATrainingProviderPage(ScenarioContext context) : base(context) => _context = context;

        public GetHelpWithFindingATrainingProviderPage EnterApprenticeshipLocation(string location)
        {
            formCompletionHelper.EnterText(ApprenticeshipLocationTextBox, location);
            return new GetHelpWithFindingATrainingProviderPage(_context);
        }

        public GetHelpWithFindingATrainingProviderPage EnterNumberOfApprentices(string noOfApprentices)
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(NumberOfApprenticesTextBox, noOfApprentices);
            return new GetHelpWithFindingATrainingProviderPage(_context);
        }
        public GetHelpWithFindingATrainingProviderPage EnterOrganisationName(string organisationName)
        {
            formCompletionHelper.EnterText(OrganisationNameTextBox, organisationName);
            return new GetHelpWithFindingATrainingProviderPage(_context);
        }
        public GetHelpWithFindingATrainingProviderPage EnterOrganisationEmailAddress(string organisationEmailAddress)
        {
            formCompletionHelper.EnterText(OrganisationEmailAddressTextBox, organisationEmailAddress);
            return new GetHelpWithFindingATrainingProviderPage(_context);
        }
        public CheckYourAnswersPage ContinueToCheckYourAnswersPage()
        {
            ContinueToNextPage();
            return new CheckYourAnswersPage(_context);
        }
        public GetHelpWithFindingATrainingProviderPage SelectNoApprentices()
        {
            formCompletionHelper.SelectRadioOptionByText("No");
            return new GetHelpWithFindingATrainingProviderPage(_context);
        }
    }
}
