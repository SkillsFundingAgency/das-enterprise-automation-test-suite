using SFA.DAS.RAA.DataGenerator;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.SignUp;

public class WhatIsYourAddressPage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-l");
    protected override string PageTitle => "What is your address?";

    private static By PostCode => By.Id("Postcode");
    private static By Address => By.Id("SelectedAddress");
    private static By FindAddressButton => By.Id("find-address-btn");

    public WhatIsYourTelephoneNumberPage EnterApprenticePostCode()
    {

        formCompletionHelper.EnterText(PostCode, RandomDataGenerator.RandomPostCode());
        formCompletionHelper.Click(FindAddressButton);
        formCompletionHelper.ClickDropdownAndSelectFromDropDown(Address);

        Continue();

        return new(context);
    }
}
