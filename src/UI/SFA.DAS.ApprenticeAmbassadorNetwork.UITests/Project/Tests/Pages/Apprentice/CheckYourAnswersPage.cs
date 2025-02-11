namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class CheckYourAnswersPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Check the information you have provided before completing your registration";
        private static By ChangelinkEmployer => By.CssSelector("a[href='/onboarding/employer-search']");
        private static By ChangelinkJobtitle => By.CssSelector("a[href='/onboarding/current-job-title']");
        private static By ChangelinkRegions => By.CssSelector("a[href='/onboarding/regions']");
        private static By ChangelinkAreasOfInterest => By.CssSelector("a[href='/onboarding/areas-of-interest']");
        private static By ChangelinkPreviousEngagement => By.CssSelector("a[href='/onboarding/previous-engagement']");

        public SearchEmployerNamePage AccessChangeCurrentEmployerAndContinue()
        {
            formCompletionHelper.ClickElement(ChangelinkEmployer);
            return new SearchEmployerNamePage(context);
        }
        public CurrentJobTitlePage AccessChangeCurrentJobTitleAndContinue()
        {
            formCompletionHelper.ClickElement(ChangelinkJobtitle);
            return new CurrentJobTitlePage(context);
        }
        public RegionsPage AccessChangeCurrentRegionAndContinue()
        {
            formCompletionHelper.ClickElement(ChangelinkRegions);
            return new RegionsPage(context);
        }
        public AreasOfInterestPage AccessChangeCurrentAreasOfInterestAndContinue()
        {
            formCompletionHelper.ClickElement(ChangelinkAreasOfInterest);
            return new AreasOfInterestPage(context);
        }
        public EngagedWithAmbassadorPage AccessChangePreviousEngagementToNoAndContinue()
        {
            formCompletionHelper.ClickElement(ChangelinkPreviousEngagement);
            return new EngagedWithAmbassadorPage(context);
        }
        public RegistrationCompletePage AcceptAndSubmitApplication()
        {
            Continue();
            return new RegistrationCompletePage(context);
        }
    }
}



