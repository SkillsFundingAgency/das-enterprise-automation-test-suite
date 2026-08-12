namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;

public class InterLearnersHomePage(ScenarioContext context, bool gotourl) : InterimEmployerBasePage(context, true, gotourl)
{
    protected override string PageTitle => "Learners";

    protected override string Linktext => "Learners";
}