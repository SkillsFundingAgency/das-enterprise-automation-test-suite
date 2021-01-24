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
        private By BackToSearchApprenticeshipTraining => By.ClassName("govuk-back-link");
        #endregion

        public SearchApprenticeshipTrainingCoursePage NavigateBackFromSingleEPAOOrganisationDetailsPage()
        {
            NavigateBackToSearchApprenticeshipTraining();
            return new SearchApprenticeshipTrainingCoursePage(_context);
        }
        public SearchApprenticeshipTrainingCoursePage NavigateBackToSearchApprenticeshipTraining()
        {
            formCompletionHelper.Click(BackToSearchApprenticeshipTraining);
            return new SearchApprenticeshipTrainingCoursePage(_context);
        }
    }
}
