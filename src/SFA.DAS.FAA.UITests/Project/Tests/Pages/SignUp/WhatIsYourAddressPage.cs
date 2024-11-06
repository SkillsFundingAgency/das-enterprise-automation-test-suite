namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.SignUp;

public class WhatIsYourAddressPage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-l");

    protected override string PageTitle => "What is your address?";

    private static By PostCode => By.CssSelector("#Postcode");
    private static By Address => By.CssSelector("#SelectedAddress");
    private static By FindAddressButton => By.CssSelector("#find-address-btn");

    public WhatIsYourTelephoneNumberPage SubmitApprenticePostCode()
    {
        formCompletionHelper.EnterText(PostCode, fAAUserNameDataHelper.FaaNewUserPostCode);

        formCompletionHelper.Click(FindAddressButton);

        var allOptions = formCompletionHelper.GetAllDropDownOptions(Address).Where(x => x != "Select address").ToList();

        formCompletionHelper.SelectFromDropDownByText(Address, RandomDataGenerator.GetRandomElementFromListOfElements(allOptions));

        Continue();

        return new(context);
    }
}
