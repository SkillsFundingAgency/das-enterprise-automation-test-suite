namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class AnyWhereInEnglandPage(ScenarioContext context) : ManagingStandardsBasePage(context)
{
    protected override string PageTitle => "Can you deliver this training anywhere in England?";

    private static By YesRadio => By.Id("Yes");
    private static By NoRadio => By.Id("No");

    public ManageAStandard_TeacherPage YesDeliverAnyWhereInEngland()
    {
        formCompletionHelper.SelectRadioOptionByLocator(YesRadio);
        Continue();
        return new ManageAStandard_TeacherPage(context);
    }

    public AddAstandardPage YesDeliverAnyWhereInEngland(string standardName)
    {
        formCompletionHelper.SelectRadioOptionByLocator(YesRadio);
        Continue();
        return new AddAstandardPage(context, standardName);
    }

    public WhereCanYouDeliverTrainingPage NoDeliverAnyWhereInEngland()
    {
        formCompletionHelper.SelectRadioOptionByLocator(NoRadio);
        Continue();
        return new WhereCanYouDeliverTrainingPage(context);
    }
}
