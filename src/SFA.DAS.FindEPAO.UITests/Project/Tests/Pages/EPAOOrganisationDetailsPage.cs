using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public class EPAOOrganisationDetailsPage : FindEPAOBasePage
    {
        protected override string PageTitle => objectContext.GetEPAOOrganisationName();
        private readonly ScenarioContext _context;
        public EPAOOrganisationDetailsPage(ScenarioContext context) : base(context) => _context = context;

        #region Locators
        private By BackButton => By.ClassName("govuk-back-link");
        private By ViewOtherEndPointOrganisations => By.LinkText("View the other end-point assessment organisations");

        #endregion

        public SearchApprenticeshipTrainingCoursePage NavigateBackFromSingleEPAOOrganisationDetailsPage()
        {
            NavigateBackToSearchApprenticeshipTraining();
            return new SearchApprenticeshipTrainingCoursePage(_context);
        }
        public SearchApprenticeshipTrainingCoursePage NavigateBackToSearchApprenticeshipTraining()
        {
            formCompletionHelper.Click(BackButton);
            return new SearchApprenticeshipTrainingCoursePage(_context);
        }
        public EPAOOrganisationsPage SelectViewOtherEndPointOrganisations()
        {
            formCompletionHelper.Click(ViewOtherEndPointOrganisations);
            return new EPAOOrganisationsPage(_context);
        }

        public EPAOOrganisationsPage NavigateBackFromEPAOOrgansationDetailsPageToOrganisationPage()
        {
            NavigateBackToEPAOOrgansationPage();
            return new EPAOOrganisationsPage(_context);
        }
        public EPAOOrganisationsPage NavigateBackToEPAOOrgansationPage()
        {
            formCompletionHelper.Click(BackButton);
            return new EPAOOrganisationsPage(_context);
        }
    }
}
