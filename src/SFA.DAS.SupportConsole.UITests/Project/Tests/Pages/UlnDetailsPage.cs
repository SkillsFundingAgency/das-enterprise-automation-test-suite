namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class UlnDetailsPage : SupportConsoleBasePage
{
    protected override string PageTitle => config.UlnName;

    #region Locators
    private static By ApprenticeNameSelector => By.CssSelector(".column-three-quarters.column__double-padding-left.column__border-left .grid-row .column-full .heading-large");
    #endregion

    public UlnDetailsPage(ScenarioContext context) : base(context) => VerifyApprenticeNameHeading();

    private void VerifyApprenticeNameHeading() => pageInteractionHelper.VerifyText(ApprenticeNameSelector, PageTitle);

    public void VerifyUlnDetailsPageHeaders()
    {
        MultipleVerifyPage(new List<Func<bool>>
        {
            () => {VerifyHeaderAndValue("Unique learner number", config.Uln); return true;},
            () => {VerifyHeaderAndValue("Name", config.UlnName); return true;},
            () => {VerifyHeaderAndValue("Cohort reference", config.CohortRef); return true;}
        });
    }

    private void VerifyHeaderAndValue(string headerText, string headerValue)
    {
        var headerTextXpathQuery = $"//th[contains(text(),'{headerText}')]";
        var header = pageInteractionHelper.FindElement(By.XPath(headerTextXpathQuery));
        var parent = header.FindElement(By.XPath(".."));
        var value = parent.FindElement(By.CssSelector("td"));
        pageInteractionHelper.VerifyText(pageInteractionHelper.GetText(header), headerText);
        pageInteractionHelper.VerifyText(headerValue, pageInteractionHelper.GetText(value));
    }
}