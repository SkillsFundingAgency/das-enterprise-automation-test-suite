using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public class EPAOOrganisationsPage : FindEPAOBasePage
    {
        protected override string PageTitle => "end-point assessment organisations";

        protected override bool TakeFullScreenShot => false;

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        public EPAOOrganisationsPage(ScenarioContext context) : base(context) { }

        private By BackButton => By.ClassName("govuk-back-link");

        public EPAOOrganisationDetailsPage SelectFirstEPAOOrganisationFromList()
        {
            var firstLinkText = pageInteractionHelper.GetText(FirstResultLink);
            objectContext.SetEPAOOrganisationName(firstLinkText);
            formCompletionHelper.ClickLinkByText(firstLinkText);
            return new EPAOOrganisationDetailsPage(context);
        }
        
        public SearchApprenticeshipTrainingCoursePage NavigateBackFromEPAOOrganisationsPageToSearchApprenticeshipTrainingPage()
        {
            NavigateBackToSearchApprenticeshipTraining();
            return new SearchApprenticeshipTrainingCoursePage(context);
        }

        public SearchApprenticeshipTrainingCoursePage NavigateBackToSearchApprenticeshipTraining()
        {
            formCompletionHelper.Click(BackButton);
            return new SearchApprenticeshipTrainingCoursePage(context);
        }

        public EPAOOrganisationDetailsPage NavigateBackFromEPAOOrgansationPageToDetailsPage()
        {
            NavigateBackToEPAOOrgansationDetailsPage();
            return new EPAOOrganisationDetailsPage(context);
        }

        public EPAOOrganisationDetailsPage NavigateBackToEPAOOrgansationDetailsPage()
        {
            formCompletionHelper.Click(BackButton);
            return new EPAOOrganisationDetailsPage(context);
        }
    }
}
