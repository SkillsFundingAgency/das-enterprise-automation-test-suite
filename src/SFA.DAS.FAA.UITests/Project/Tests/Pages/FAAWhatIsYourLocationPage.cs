using System.Collections.Generic;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAAWhatIsYourLocationPage(ScenarioContext context) : FAASignedInLandingBasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-l");

    protected override string PageTitle => "What is your location?";
    private static By CityOrPostcodeTextbox => By.Id("SearchTerm");
    private static By DistanceDropdown => By.Id("Distance");

    public FAASearchResultPage EnterLocationDetails(string locationOptionText)
    {
        formCompletionHelper.SelectRadioOptionByText(locationOptionText);

        if (locationOptionText == "Enter a city or postcode")
        {
            formCompletionHelper.EnterText(CityOrPostcodeTextbox, "SW1A Westminster");
            formCompletionHelper.SelectFromDropDownByValue(DistanceDropdown, "40");
        }

        formCompletionHelper.ClickButtonByText(ContinueButton, "Search");
        return new FAASearchResultPage(context);
    }
}
