namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CancelEvent;

public class CancelEventPage : AanAdminBasePage
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-m");

    protected override string PageTitle => aanAdminCreateEventDatahelper.EventTitle;

    private static By CancelButton => By.CssSelector("button[type='submit'][id='continue']");

    public CancelEventPage(ScenarioContext context) : base(context, false) => VerifyPage();

    public SucessfullyCancelledEventPage CancelEvent()
    {
        SelectCheckBoxByText("Yes");

        formCompletionHelper.Click(CancelButton);

        return new SucessfullyCancelledEventPage(context);
    }
}
