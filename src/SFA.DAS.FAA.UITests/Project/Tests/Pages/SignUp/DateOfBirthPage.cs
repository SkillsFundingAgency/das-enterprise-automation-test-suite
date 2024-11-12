namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.SignUp;

public class DateOfBirthPage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");
    protected override string PageTitle => "Date of birth";

    private static By Day => By.CssSelector("#DateOfBirthDay");
    private static By Month => By.CssSelector("#DateOfBirthMonth");
    private static By Year => By.CssSelector("#DateOfBirthYear");


    public WhatIsYourAddressPage SubmitApprenticeDateOfBirth()
    {
        var dob = fAAUserNameDataHelper.FaaNewUserDob;

        formCompletionHelper.EnterText(Day, dob.Day);
        formCompletionHelper.EnterText(Month, dob.Month);
        formCompletionHelper.EnterText(Year, dob.Year);

        Continue();

        return new(context);
    }
}
