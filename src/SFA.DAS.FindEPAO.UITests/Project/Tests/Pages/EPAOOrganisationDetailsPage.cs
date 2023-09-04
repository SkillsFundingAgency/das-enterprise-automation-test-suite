using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public class EPAOOrganisationDetailsPage : FindEPAOBasePage
    {
        protected override string PageTitle => objectContext.GetEPAOOrganisationName();

        public EPAOOrganisationDetailsPage(ScenarioContext context) : base(context) { }

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
