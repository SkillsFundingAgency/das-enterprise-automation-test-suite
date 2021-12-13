using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public class SearchApprenticeshipTrainingCoursePage : FindEPAOBasePage
    {
        protected override string PageTitle => "What is the apprenticeship training course?";

        public SearchApprenticeshipTrainingCoursePage(ScenarioContext context) : base(context) { } 

        #region Locators
        private By BackButton => By.ClassName("govuk-back-link");
        #endregion

        public EPAOOrganisationsPage SearchForApprenticeshipStandardInSearchApprenticeshipTrainingCoursePage(string searchTerm)
        {
            SearchApprenticeshipStandard(searchTerm);
            return new EPAOOrganisationsPage(context);
        }

        public ZeroAssessmentOrganisationsPage SearchForApprenticeshipStandardWithNoEPAO(string searchTerm)
        {
            SearchApprenticeshipStandard(searchTerm);
            return new ZeroAssessmentOrganisationsPage(context);
        }

        public EPAOOrganisationDetailsPage SearchForApprenticeshipStandardWithSingleEPAO(string searchTerm)
        {
            SearchApprenticeshipStandard(searchTerm);
            return new EPAOOrganisationDetailsPage(context);
        }

        public EPAOOrganisationsPage SearchForAnIntegratedApprenticeshipStandard(string searchTerm)
        {
            SearchApprenticeshipStandard(searchTerm);
            return new EPAOOrganisationsPage(context);
        }

        public FindEPAOIndexPage NavigateBackFromSearchApprenticeshipPageToHomePage()
        {
            NavigateBackToHomePage();
            return new FindEPAOIndexPage(context);
        }
        public FindEPAOIndexPage NavigateBackToHomePage()
        {
            formCompletionHelper.Click(BackButton);
            return new FindEPAOIndexPage(context);
        }
    }
}
