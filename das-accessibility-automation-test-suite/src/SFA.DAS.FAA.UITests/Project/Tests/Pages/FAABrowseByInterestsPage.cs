using System.Collections.Generic;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAABrowseByInterestsPage(ScenarioContext context) : FAASignedInLandingBasePage(context)
{
    protected override By PageHeader => By.Id("SelectedRouteIds");

    protected override string PageTitle => "Browse by your interests";

    public FAAWhatIsYourLocationPage SelectCategoriesCheckBoxes()
    {
        var categoryIds = new List<string>
        {
            "#route-12",
            "#route-7"
        };

        foreach (var category in categoryIds)
        {
            formCompletionHelper.SelectCheckBoxByActions(By.CssSelector(category));
        }

        formCompletionHelper.ClickButtonByText(ContinueButton, "Continue");
        return new FAAWhatIsYourLocationPage(context);
    }
}
