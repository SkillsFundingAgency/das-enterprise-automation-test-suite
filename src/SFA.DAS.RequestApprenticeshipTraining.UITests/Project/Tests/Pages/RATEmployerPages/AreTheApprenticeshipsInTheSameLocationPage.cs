using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages;

public class AreTheApprenticeshipsInTheSameLocationPage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "Are the apprenticeships in the same location?";

    #region Locators
    private static By ClickYesIfSame => By.CssSelector("label[for='SameLocation']");

    private static By ClickNoIfNot => By.CssSelector("label[for='SameLocation-no']");
    #endregion

    public WhereIsTheApprenticeshipLocationPage ClickYesForASingleLocation() => GoToLocationPage(true);

    public WhereIsTheApprenticeshipLocationPage ClickNoForAMultipleLocation() => GoToLocationPage(false);

    private WhereIsTheApprenticeshipLocationPage GoToLocationPage(bool IsSingleLocation)
    {
        formCompletionHelper.Click(IsSingleLocation ? ClickYesIfSame : ClickNoIfNot);

        Continue();

        return new WhereIsTheApprenticeshipLocationPage(context, IsSingleLocation);
    }
}