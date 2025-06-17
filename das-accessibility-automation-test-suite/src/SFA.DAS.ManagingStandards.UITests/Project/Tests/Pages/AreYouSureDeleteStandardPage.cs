namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class AreYouSureDeleteStandardPage(ScenarioContext context) : ManagingStandardsBasePage(context)
{
    protected override string PageTitle => "Are you sure you want to delete this standard?";

    private static By DeleteStandardButton => By.Id("DeleteStandard");

    public ManageTheStandardsYouDeliverPage DeleteStandard()
    {
        formCompletionHelper.ClickElement(DeleteStandardButton);
        return new ManageTheStandardsYouDeliverPage(context);
    }
}
