namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class AnyWhereInEnglandPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Can you deliver this training anywhere in England?";

    private static By YesRadio => By.Id("Yes");
    private static By NoRadio => By.Id("No");

    public AnyWhereInEnglandPage(ScenarioContext context) : base(context) { }

    public ManageAStandard_TeacherPage YesDeliverAnyWhereInEngland()
    {
        formCompletionHelper.SelectRadioOptionByLocator(YesRadio);
        Continue();
        return new ManageAStandard_TeacherPage(context);
    }

    public WhereCanYouDeliverTrainingPage NoDeliverAnyWhereInEngland()
    {
        formCompletionHelper.SelectRadioOptionByLocator(NoRadio);
        Continue();
        return new WhereCanYouDeliverTrainingPage(context);
    }
}
