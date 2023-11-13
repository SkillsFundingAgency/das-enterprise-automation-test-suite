namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public abstract class ChangeBasePage : RoatpAdminBasePage
{
    public ChangeBasePage(ScenarioContext context) : base(context) { }

    public ResultsFoundPage ClickBackLink()
    {
        Back();
        return new ResultsFoundPage(context);
    }
}
