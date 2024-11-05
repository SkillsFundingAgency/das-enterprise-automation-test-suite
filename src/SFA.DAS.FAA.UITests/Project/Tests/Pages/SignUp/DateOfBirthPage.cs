namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.SignUp;

public class DateOfBirthPage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");
    protected override string PageTitle => "Date of birth";

    private static By Day => By.Id("DateOfBirthDay");
    private static By Month => By.Id("DateOfBirthMonth");
    private static By Year => By.Id("DateOfBirthYear");


    public WhatIsYourAddressPage EnterApprenticeDateOfBirth()
    {

        formCompletionHelper.EnterText(Day, RandomDataGenerator.GenerateRandomDateOfMonth());
        formCompletionHelper.EnterText(Month, RandomDataGenerator.GenerateRandomMonth());
        formCompletionHelper.EnterText(Year, RandomDataGenerator.GenerateRandomDobYear());

        Continue();

        return new(context);
    }
}
