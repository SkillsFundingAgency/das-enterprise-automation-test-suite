namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.SignUp;

public class GetRemindersAboutYourUnfinishedApplicationsPage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-l");
    protected override string PageTitle => "Get reminders about your unfinished applications";

    private static By NotificationOption => By.Id("IsRemindersOpt-2");

    public CheckYourAccountDetailsPage SelectRemindersNotification()
    {

        formCompletionHelper.SelectRadioOptionByLocator(NotificationOption);

        Continue();

        return new(context);
    }
}
