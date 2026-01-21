using System;

namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class SearchPage : RoatpAdminBasePage
{
    protected override string PageTitle => "Search for a training provider";

    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

    private static By Confirmation => By.CssSelector(".govuk-panel--confirmation");

    private static By ProviderSearch => By.Id("SearchTerm");

    public SearchPage(ScenarioContext context) : base(context) => VerifyPage();

    public SearchPage VerifyNewProviderHasBeenAdded()
    {
        pageInteractionHelper.VerifyText(Confirmation, $"{objectContext.GetProviderName()} has been added");
        return this;
    }

    public ResultsFoundPage SearchTrainingProviderByName() => SearchTrainingProvider(objectContext.GetProviderName());

    public ResultsFoundPage SearchTrainingProviderByUkprn() => SearchTrainingProvider(objectContext.GetUkprn());

    public void SearchTrainingProviderByName_NoResults() => SearchTrainingProvider(objectContext.GetUkprn());

    public ResultsFoundPage SearchTrainingProvider(string text)
    {
        formCompletionHelper.EnterText(ProviderSearch, text);

        // Wait for autocomplete to expand
        pageInteractionHelper.WaitForElementToChange(
            ProviderSearch,
            "aria-expanded",
            "true");

        // Wait for options to be present
        pageInteractionHelper.WaitForElementToBeDisplayed(
            By.CssSelector(".autocomplete__option"));

        var option = pageInteractionHelper
            .FindElements(By.CssSelector(".autocomplete__option"))
            .First(o => o.Text.Contains(text, StringComparison.OrdinalIgnoreCase));

        option.Click();

        Continue();
        return new ResultsFoundPage(context);
    }



    public RoatpAdminHomePage ReturnToDahsboard()
    {
        formCompletionHelper.ClickLinkByText("Dashboard");
        return new RoatpAdminHomePage(context);
    }
}
