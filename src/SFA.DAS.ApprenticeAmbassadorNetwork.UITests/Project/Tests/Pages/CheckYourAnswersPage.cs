namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class CheckYourAnswersPage : AanBasePage
    {
        protected override string PageTitle => "Check the information you have provided before submitting your application";
        private By ChangelinkEmployer = By.CssSelector("a[href='/onboarding/employer-search']");
        private By ChangelinkJobtitle = By.CssSelector("a[href='/onboarding/current-job-title']");
        private By ChangelinkRegions = By.CssSelector("a[href='/onboarding/regions']");
        private By ChangelinkAreasOfInterest = By.CssSelector("a[href='/onboarding/areas-of-interest']");
        private By ChangelinkPreviousEngagement = By.CssSelector("a[href='/onboarding/previous-engagement']");
        public CheckYourAnswersPage(ScenarioContext context) : base(context) => VerifyPage();

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
        public ApplicationSubmittedPage AcceptAndSubmitApplication()
        {
            Continue();
            return new ApplicationSubmittedPage(context);
        }
    }
}



