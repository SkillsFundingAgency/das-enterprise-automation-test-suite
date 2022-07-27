
namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class WhereWillThisStandardBeDeliveredPage : VerifyBasePage
{
    protected override string PageTitle => "Where will this standard be delivered";

    private static By AtOneOfYourTrainingLocationsRadio => By.Id("ProviderLocationOption");
    private static By AtAnEmployersLocationRadio => By.Id("EmployerLocationOption");
    private static By BothRadio => By.Id("BothLocationOption");

    public WhereWillThisStandardBeDeliveredPage(ScenarioContext context) : base(context) => VerifyPage();

    public TrainingLocation_ConfirmVenuePage ConfirmAtOneofYourTrainingLocations()
    {
        formCompletionHelper.SelectRadioOptionByLocator(AtOneOfYourTrainingLocationsRadio);
        Continue();
        return new TrainingLocation_ConfirmVenuePage(context);
    }

    public AnyWhereInEnglandPage ConfirmAtAnEmployersLocation()
    {
        formCompletionHelper.SelectRadioOptionByLocator(AtAnEmployersLocationRadio);
        Continue();
        return new AnyWhereInEnglandPage(context);
    }

    public TrainingLocation_ConfirmVenuePage ConfirmStandardWillDeliveredInBoth()
    {
        formCompletionHelper.SelectRadioOptionByLocator(BothRadio);
        Continue();
        return new TrainingLocation_ConfirmVenuePage(context);
    }
}
