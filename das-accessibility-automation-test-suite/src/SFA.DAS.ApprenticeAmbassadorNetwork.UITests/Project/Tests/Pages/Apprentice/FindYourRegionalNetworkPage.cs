using System;
using System.Threading;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

public class FindYourRegionalNetworkPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Find your regional network";

    private static By LondonRadio => By.Id("region-London");
    private static By NorthEasstRadio => By.Id("region-North-East");

    public YourRegionalNetworkPage SelectARegionAndContinue()
    {
        formCompletionHelper.SelectRadioOptionByLocator(LondonRadio);
        //pageInteractionHelper.WaitForElementToBeDisplayed(FirstAddress);
        Thread.Sleep(TimeSpan.FromSeconds(5));
        Continue();
        return new YourRegionalNetworkPage(context);
    }

    public CheckYourAnswersPage AddOneMoreRegionAndContinue()
    {
        formCompletionHelper.SelectRadioOptionByLocator(NorthEasstRadio);
        Continue();
        Continue();
        return new CheckYourAnswersPage(context);
    }
}