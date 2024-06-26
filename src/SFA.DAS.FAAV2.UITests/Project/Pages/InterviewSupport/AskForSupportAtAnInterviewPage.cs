namespace SFA.DAS.FAAV2.UITests.Project.Pages.InterviewSupport;

public class AskForSupportAtAnInterviewPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Ask for support at an interview";

    private static By InterviewAdjustmentsDescription => By.CssSelector("#InterviewAdjustmentsDescription");

    protected override By ContinueButton => By.CssSelector("button.govuk-button[type='submit']");

    public GetSupportAtAnInterviewPage SelectYesAndContinue()
    {
        SelectRadioOptionByForAttribute("DoYouWantInterviewAdjustments");

        formCompletionHelper.EnterText(InterviewAdjustmentsDescription, faaDataHelper.InterviewSupport);
        Continue();
        return new(context);
    }

    public GetSupportAtAnInterviewPage SelectNoAndContinue()
    {
        SelectRadioOptionByForAttribute("interview-adjustments-false");
        Continue();
        return new(context);
    }
}