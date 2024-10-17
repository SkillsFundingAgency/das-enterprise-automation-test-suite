using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Employer;

public class SelectTrainingOptionsPage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "Select training options";

    #region Locators
    private static By AtApprenticesWorkplace => By.CssSelector("label[for='AtApprenticesWorkplace']");
    private static By DayRelease => By.CssSelector("label[for='DayRelease']");
    private static By BlockRelease => By.CssSelector("label[for='BlockRelease']");
    #endregion

    public CheckYourAnswersPage SelectTrainingOptions()
    {
        formCompletionHelper.Click(AtApprenticesWorkplace);
        formCompletionHelper.Click(DayRelease);
        formCompletionHelper.Click(BlockRelease);
        Continue();
        return new CheckYourAnswersPage(context);
    }
}
