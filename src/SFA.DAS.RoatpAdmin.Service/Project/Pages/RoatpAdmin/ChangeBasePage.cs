namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public abstract class ChangeBasePage(ScenarioContext context) : RoatpAdminBasePage(context)
{
    public ResultsFoundPage ClickBackLink()
    {
        Back();
        return new ResultsFoundPage(context);
    }
}
