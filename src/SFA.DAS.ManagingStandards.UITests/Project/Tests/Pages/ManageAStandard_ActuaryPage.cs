namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class ManageAStandard_ActuaryPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Actuary (Level 7)";

    public ManageAStandard_ActuaryPage(ScenarioContext context) : base(context) { }

    public AreYouSureDeleteStandardPage ClickDeleteAStandard()
    {
        formCompletionHelper.ClickLinkByText("Delete standard");
        return new AreYouSureDeleteStandardPage(context);
    }
}
