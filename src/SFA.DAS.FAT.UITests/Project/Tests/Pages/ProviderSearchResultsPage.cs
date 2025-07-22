namespace SFA.DAS.FAT.UITests.Project.Tests.Pages;

public class ProviderShortListedResultPage(ScenarioContext context) : ProviderSearchResultsPage(context)
{
    protected override string PageTitle => "Shortlisted";

    protected override By PageHeader => By.CssSelector(".govuk-tag.app-provider-shortlist-tag");
}

public class ProviderSearchResultsPage(ScenarioContext context) : FATBasePage(context)
{
    protected override string PageTitle => "Training providers for";

    protected override bool TakeFullScreenShot => false;

    protected override By PageHeader => By.ClassName("govuk-heading-xl");

    private static By AskIfTrainingProvidersCanRunThisCourseLink => By.LinkText("Ask if training providers can run this course");

    #region Locators
    private static By SpecifiedProvider(string provider) => By.Id($"provider-{provider}");
    private static By BackToCourseSummaryPage => By.Id("course-detail-breadcrumb");
    private static By AddToShortlist => By.CssSelector("button[id^='add-to-shortlist-']");
    private static By RemoveLocation => By.LinkText("Clear");

    #endregion

    public void RequestTrainingProvider() => formCompletionHelper.Click(AskIfTrainingProvidersCanRunThisCourseLink);

    public ProviderSummaryPage SelectFirstProviderInTheList()
    {
        var firstProviderLinkText = pageInteractionHelper.GetText(FirstProviderResultLink);
        objectContext.SetProviderName(firstProviderLinkText);
        formCompletionHelper.ClickLinkByText(firstProviderLinkText);
        return new ProviderSummaryPage(context);
    }
    public ApprenticeshipTrainingCourseSummaryPage NavigateBackFromTrainingProvidersPage()
    {
        NavigateBackToTrainingProviders();
        return new ApprenticeshipTrainingCourseSummaryPage(context);
    }
    public ApprenticeshipTrainingCourseSummaryPage NavigateBackToTrainingProviders()
    {
        formCompletionHelper.Click(BackToCourseSummaryPage);
        return new ApprenticeshipTrainingCourseSummaryPage(context);
    }
    public ProviderShortListedResultPage ShortlistAProviderFromProviderList()
    {
        formCompletionHelper.Click(AddToShortlist);
        return new ProviderShortListedResultPage(context);
    }
    public ProviderSearchResultsPage RemoveLocationOnProviderListPage()
    {
        formCompletionHelper.Click(RemoveLocation);
        return new ProviderSearchResultsPage(context);
    }
    public ProviderShortlistPage NavigateToProviderShortlistPage()
    {
        NavigateToShortlistPage();
        return new ProviderShortlistPage(context);
    }

    public ProviderSummaryPage ClickSpecifiedProvider(string provider) { formCompletionHelper.Click(SpecifiedProvider(provider)); return new(context); }
}
