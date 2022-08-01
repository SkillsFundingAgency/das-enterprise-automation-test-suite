namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public abstract class ManagingStandardsBasePage : VerifyBasePage
{
    protected readonly ManagingStandardsDataHelpers managingStandardsDataHelpers;

    public ManagingStandardsBasePage(ScenarioContext context, bool verifyPage = true) : base(context)
    {
        managingStandardsDataHelpers = context.Get<ManagingStandardsDataHelpers>();

        if (verifyPage) VerifyPage();
    }
}
