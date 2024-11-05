namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.SignUp;

public class WhatIsYourTelephoneNumberPage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-l");
    protected override string PageTitle => "What is your telephone number?";

    private static By TelephoneNumber => By.Id("PhoneNumber");

    public GetRemindersAboutYourUnfinishedApplicationsPage EnterApprenticeTelephoneNumber()
    {

        formCompletionHelper.EnterText(TelephoneNumber, RandomDataGenerator.GenerateRandomPhoneNumber(11));

        Continue();

        return new(context);
    }
}
