namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;

public class InterimApprenticesHomePage(ScenarioContext context, bool gotourl) : InterimEmployerBasePage(context, true, gotourl)
{
    protected override string PageTitle => "Learners";

    protected override string Linktext => "Apprentices";
}