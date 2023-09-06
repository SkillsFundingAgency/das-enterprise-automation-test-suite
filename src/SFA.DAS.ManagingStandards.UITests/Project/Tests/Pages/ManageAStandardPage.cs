namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class ManageAStandardPage : ManagingStandardsBasePage
{
    protected override string PageTitle => _pageTitle;

    protected override string AccessibilityPageTitle => "Manage a standard page";


    private readonly string _pageTitle;

    public ManageAStandardPage(ScenarioContext context, string standardName) : base(context, false)
    {
        _pageTitle = standardName;

        VerifyPage();
    }

    public AreYouSureDeleteStandardPage ClickDeleteAStandard()
    {
        formCompletionHelper.ClickLinkByText("Delete standard");
        return new AreYouSureDeleteStandardPage(context);
    }
}
