namespace SFA.DAS.ManagingStandards.UITests.Project.Helpers;

public class StepsHelper
{
    private readonly ScenarioContext _context;
    private readonly FormCompletionHelper formCompletionHelper;

    public StepsHelper(ScenarioContext context)
    {
        _context = context;
        formCompletionHelper = _context.Get<FormCompletionHelper>();
    }

    public void NavigateToReviewYourDetails()
    {
        formCompletionHelper.ClickLinkByText("Your standards and training venues");
    }
}
