namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.SignUp;

public class WhatIsYourTelephoneNumberPage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-l");
    protected override string PageTitle => "What is your telephone number?";

    private static By TelephoneNumber => By.Id("PhoneNumber");

    public GetRemindersAboutYourUnfinishedApplicationsPage SubmitApprenticeTelephoneNumber()
    {
        formCompletionHelper.EnterText(TelephoneNumber, fAAUserNameDataHelper.FaaNewUserMobilePhone);

        Continue();

        return new(context);
    }
}
