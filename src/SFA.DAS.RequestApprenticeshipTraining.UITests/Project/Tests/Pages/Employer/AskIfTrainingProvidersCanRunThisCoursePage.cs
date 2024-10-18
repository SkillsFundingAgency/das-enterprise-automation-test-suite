using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Employer;

public class AskIfTrainingProvidersCanRunThisCoursePage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "Ask if training providers can run this course";

    #region Locators
    private static By ClickStartNowButton => By.CssSelector("a.govuk-button.govuk-button--start");
    #endregion

    public HowManyAprenticesWouldDoThisApprenticeshipTrainingPage ClickStarNow()
    {
        formCompletionHelper.Click(ClickStartNowButton);

        return new HowManyAprenticesWouldDoThisApprenticeshipTrainingPage(context);
    }
}