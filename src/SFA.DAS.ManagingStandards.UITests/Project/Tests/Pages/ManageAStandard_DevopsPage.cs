namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class ManageAStandard_DevopsPage : VerifyBasePage
{
    protected override string PageTitle => "DevOps engineer (Level 4)";

    public ManageAStandard_DevopsPage(ScenarioContext context) : base(context) => VerifyPage();

    public YourContactInformationForThisStandardPage UpdateTheseContactDetails()
    {
        formCompletionHelper.ClickLinkByText("Update these contact details");
        return new YourContactInformationForThisStandardPage(context);
    }

}
