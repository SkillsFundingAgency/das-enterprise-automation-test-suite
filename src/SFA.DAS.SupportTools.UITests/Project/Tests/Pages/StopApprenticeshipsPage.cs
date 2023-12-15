namespace SFA.DAS.SupportTools.UITests.Project.Tests.Pages;

public class StopApprenticeshipsPage(ScenarioContext context) : ToolSupportBasePage(context)
{
    protected override string PageTitle => "Stop apprenticeships";

    #region Locators
    private static By StopApprenticeshipsbtn => By.Id("okButton");
    private static By StopDate => By.Id("bulkDate");
    private static By DateInputBox => By.Id("date_0");
    private static By SetBtn => By.Id("btnSetBulkDate");
    private static By StatusColumn => By.CssSelector("#apprenticeshipsTable tr td:nth-child(12)");
    private static By ErrorMessage => By.XPath("//li[contains(text(),'Not all Apprenticeship rows have been supplied wit')]");

    #endregion

    public StopApprenticeshipsPage ClickStopBtn()
    {
        formCompletionHelper.Click(StopApprenticeshipsbtn);
        return this;
    }

    public StopApprenticeshipsPage ValidateErrorMessage()
    {
        pageInteractionHelper.IsElementDisplayed(ErrorMessage);
        return this;
    }

    public List<IWebElement> GetStatusColumn() => pageInteractionHelper.FindElements(StatusColumn);

    public StopApprenticeshipsPage EnterStopDateAndClickSetbutton()
    {
        string stopDate = "01/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year.ToString("0000");
        pageInteractionHelper.WaitForElementToBeClickable(StopDate);
        formCompletionHelper.EnterText(StopDate, stopDate);
        formCompletionHelper.Click(SetBtn);
        return this;
    }

    public StopApprenticeshipsPage ValidateStopDateApplied()
    {
        var actualDate = pageInteractionHelper.FindElement(DateInputBox).GetAttribute("value");
        string expectedDate1 = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-01";
        string expectedDate2 = DateTime.Now.Year + "-01-" + DateTime.Now.Month.ToString("00");
        Assert.IsTrue(expectedDate1 == actualDate || expectedDate2 == actualDate, "Validate correct stop date has been set in the table");
        return this;
    }
}
