namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class TrainingLocation_ConfirmVenuePage : VerifyBasePage
{
    protected override string PageTitle => "Training locations";

    public TrainingLocation_ConfirmVenuePage(ScenarioContext context) : base(context) => VerifyPage();

    public ManageAStandard_TeacherPage ConfirmVenueDetailsAndDeliveryMethod_AtOneOFYourTrainingLocation()
    {
        Continue();
        return new ManageAStandard_TeacherPage(context);
    }

    public AnyWhereInEnglandPage ConfirmVenueDetailsAndDeliveryMethod_AtBoth()
    {
        Continue();
        return new AnyWhereInEnglandPage(context);
    }

}
