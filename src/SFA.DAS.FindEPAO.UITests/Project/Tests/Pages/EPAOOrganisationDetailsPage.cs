using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public class EPAOOrganisationDetailsPage(ScenarioContext context) : FindEPAOBasePage(context)
    {
        protected override string PageTitle => objectContext.GetEPAOOrganisationName();

        protected override string AccessibilityPageTitle => "EPAO organisation name Page";

        #region Locators
        private static By BackButton => By.ClassName("govuk-back-link");
        private static By ViewOtherEndPointOrganisations => By.LinkText("View the other end-point assessment organisations");

        #endregion

        public SearchApprenticeshipTrainingCoursePage NavigateBackFromSingleEPAOOrganisationDetailsPage()
        {
            NavigateBackToSearchApprenticeshipTraining();
            return new SearchApprenticeshipTrainingCoursePage(context);
        }
        public SearchApprenticeshipTrainingCoursePage NavigateBackToSearchApprenticeshipTraining()
        {
            formCompletionHelper.Click(BackButton);
            return new SearchApprenticeshipTrainingCoursePage(context);
        }
        public EPAOOrganisationsPage SelectViewOtherEndPointOrganisations()
        {
            formCompletionHelper.Click(ViewOtherEndPointOrganisations);
            return new EPAOOrganisationsPage(context);
        }

        public EPAOOrganisationsPage NavigateBackFromEPAOOrgansationDetailsPageToOrganisationPage()
        {
            NavigateBackToEPAOOrgansationPage();
            return new EPAOOrganisationsPage(context);
        }
        public EPAOOrganisationsPage NavigateBackToEPAOOrgansationPage()
        {
            formCompletionHelper.Click(BackButton);
            return new EPAOOrganisationsPage(context);
        }
    }
}
