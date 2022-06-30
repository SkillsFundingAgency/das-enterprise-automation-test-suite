namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class UlnDetailsPage : SupportConsoleBasePage
{
    protected override string PageTitle => cohortDetails.UlnName;

    protected override By PageHeader => By.CssSelector(".heading-large");

    private readonly CohortDetails cohortDetails;

    public UlnDetailsPage(ScenarioContext context, CohortDetails cohortDetails) : base(context)
    {
        this.cohortDetails = cohortDetails;

        VerifyPage(() => pageInteractionHelper.FindElements(PageHeader), PageTitle);
    }

    public void VerifyUlnDetailsPageHeaders()
    {
        MultipleVerifyPage(new List<Func<bool>>
        {
            () => {VerifyHeaderAndValue("Unique learner number", cohortDetails.Uln); return true;},
            () => {VerifyHeaderAndValue("Name", cohortDetails.UlnName); return true;},
            () => {VerifyHeaderAndValue("Cohort reference", cohortDetails.CohortRef); return true;}
        });
    }

    protected void ClickTab(By by) => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(by));

    protected void IsTabDisplayed(By by) => Assert.IsTrue(pageInteractionHelper.FindElements(by).Count > 0);

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