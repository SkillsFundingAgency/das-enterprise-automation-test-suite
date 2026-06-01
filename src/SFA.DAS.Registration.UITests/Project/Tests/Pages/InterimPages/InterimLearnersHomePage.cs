namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;

public class InterimLearnersHomePage(ScenarioContext context, bool gotourl) : InterimEmployerBasePage(context, true, gotourl)
{
    protected override string PageTitle => "Learners";

    protected override string Linktext => "Apprentices";
}