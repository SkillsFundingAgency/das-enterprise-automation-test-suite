
namespace SFA.DAS.FAAV2.UITests.Project.Pages;

public partial class FAA_ApplicationOverviewPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => $"Apply for {vacancyTitleDataHelper.VacancyTitle}";

}
