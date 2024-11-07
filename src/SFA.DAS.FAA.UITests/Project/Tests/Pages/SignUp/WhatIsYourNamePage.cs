namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.SignUp;

public class WhatIsYourNamePage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "What is your name?";

    private static By FirstName => By.CssSelector("#FirstName");
    private static By LastName => By.CssSelector("#LastName");

    public DateOfBirthPage SubmitApprenticeName()
    {
        formCompletionHelper.EnterText(FirstName, fAAUserNameDataHelper.FirstName);

        formCompletionHelper.EnterText(LastName, fAAUserNameDataHelper.LastName);

        Continue();

        return new(context);
    }

}
