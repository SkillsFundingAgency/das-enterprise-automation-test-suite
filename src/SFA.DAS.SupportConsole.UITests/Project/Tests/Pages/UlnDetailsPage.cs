namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class UlnDetailsPage : SupportConsoleBasePage
{
    protected override string PageTitle => config.UlnName;

    protected override By PageHeader => By.CssSelector(".heading-large");

    public UlnDetailsPage(ScenarioContext context) : base(context) => VerifyPage(() => pageInteractionHelper.FindElements(PageHeader), PageTitle);

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