using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.ApplicationQuestions;

public class AdditionQuestion1Page(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => pageInteractionHelper.FindElement(PageHeader).Text;

    protected override By PageHeader => By.CssSelector("label[for='AdditionalQuestionAnswer']");
    private static By AdditionalQuestionAnswer => By.CssSelector("#AdditionalQuestionAnswer");

    public FAA_ApplicationOverviewPage SelectYesAndCompleteSection()
    {
        formCompletionHelper.EnterText(AdditionalQuestionAnswer, faaDataHelper.AdditionalQuestions1Answer);

        SelectRadioOptionByForAttribute("IsSectionCompleted");

        Continue();

        return new(context);
    }
}
