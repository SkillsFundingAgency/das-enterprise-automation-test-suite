using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages
{
    public class GetHelpWithFindingATrainingProviderPage : AEDBasePage
    {
        protected override string PageTitle => "Get help with finding a training provider";
        protected override By PageHeader => By.ClassName("govuk-heading-xl");

        #region Locators
        private By NumberOfApprenticesTextBox => By.Id("NumberOfApprentices");
        private By ApprenticeshipLocationTextBox => By.Id("search-location");
        private By OrganisationNameTextBox => By.Id("OrganisationName");
        private By OrganisationEmailAddressTextBox => By.Id("ContactEmailAddress");
        #endregion

        public GetHelpWithFindingATrainingProviderPage(ScenarioContext context) : base(context)  { }

        public GetHelpWithFindingATrainingProviderPage EnterApprenticeshipLocation(string location)
        {
            formCompletionHelper.EnterText(ApprenticeshipLocationTextBox, location);
            return new GetHelpWithFindingATrainingProviderPage(context);
        }

        public GetHelpWithFindingATrainingProviderPage EnterNumberOfApprentices(string noOfApprentices)
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(NumberOfApprenticesTextBox, noOfApprentices);
            return new GetHelpWithFindingATrainingProviderPage(context);
        }
        public GetHelpWithFindingATrainingProviderPage EnterOrganisationName(string organisationName)
        {
            formCompletionHelper.EnterText(OrganisationNameTextBox, organisationName);
            return new GetHelpWithFindingATrainingProviderPage(context);
        }
        public GetHelpWithFindingATrainingProviderPage EnterOrganisationEmailAddress(string organisationEmailAddress)
        {
            formCompletionHelper.EnterText(OrganisationEmailAddressTextBox, organisationEmailAddress);
            return new GetHelpWithFindingATrainingProviderPage(context);
        }
        public CheckYourAnswersPage ContinueToCheckYourAnswersPage()
        {
            ContinueToNextPage();
            return new CheckYourAnswersPage(context);
        }
        public GetHelpWithFindingATrainingProviderPage SelectNoApprentices()
        {
            formCompletionHelper.SelectRadioOptionByText("No");
            return new GetHelpWithFindingATrainingProviderPage(context);
        }
    }
}
