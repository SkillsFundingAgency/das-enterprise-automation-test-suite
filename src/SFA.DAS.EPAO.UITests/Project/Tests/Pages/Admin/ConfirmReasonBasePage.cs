namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public abstract class ConfirmReasonBasePage : EPAOAdmin_BasePage
{
    #region Helpers and Context
    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
    protected static By IncidentNumberField => By.Id("IncidentNumber");
    #endregion

    public ConfirmReasonBasePage(ScenarioContext context) : base(context) => VerifyPage();

    public CheckAndSubmitAssessmentDetailsPage EnterTicketRefeferenceAndSelectReason(string ticketReference, string reasonForReprint)
    {
        formCompletionHelper.EnterText(IncidentNumberField, ticketReference);
        SelectCheckBoxByText(reasonForReprint);
        Continue();
        return new(context);
    }
}