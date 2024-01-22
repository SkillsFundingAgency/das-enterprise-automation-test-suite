using SFA.DAS.UI.Framework.TestSupport.CheckPage;

namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.DfeSignPages;

public abstract class NotADfeSignPage(ScenarioContext context) : CheckPageTitleLongerTimeOut(context)
{
    protected override string PageTitle => DfeSignInPage.DfePageTitle;

    protected override By Identifier { get; }

    protected override By PageHeader => Identifier;

    public override bool IsPageDisplayed()
    {
        SetDebugInformation($"Check page title is NOT : '{PageTitle}'");

        return checkPageInteractionHelper.Verify(() =>
        {
            var result = IsPageCurrent;

            return result.Item1 ? throw new Exception(MessageHelper.GetExceptionMessage("'Dfe Sign'", $"Should have navigated from '{PageTitle}'", result.Item2)) : true;

        }, null);
    }
}