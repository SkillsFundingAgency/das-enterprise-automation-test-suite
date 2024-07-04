namespace SFA.DAS.FAAV2.UITests.Project.Tests.Pages.ApplicationQuestions;

public class AdditionQuestion2Page(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => advertDataHelper.AdditionalQuestion2;

    protected override By ContinueButton => By.CssSelector("button.govuk-button[data-module='govuk-button']");

    private static By AdditionalQuestionAnswer => By.CssSelector("#AdditionalQuestionAnswer");

    public FAA_ApplicationOverviewPage SelectYesAndCompleteSection()
    {
        formCompletionHelper.EnterText(AdditionalQuestionAnswer, faaDataHelper.AdditionalQuestions2Answer);

        SelectRadioOptionByForAttribute("IsSectionCompleted");

        Continue();

        return new(context);
    }
}