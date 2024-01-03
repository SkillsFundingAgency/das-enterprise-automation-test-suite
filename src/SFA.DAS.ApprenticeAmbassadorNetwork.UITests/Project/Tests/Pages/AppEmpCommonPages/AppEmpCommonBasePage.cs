namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public abstract class AppEmpCommonBasePage(ScenarioContext context, bool verifyPage) : AanBasePage(context, verifyPage)
{
    protected void GoToId(string id)
    {
        var url = pageInteractionHelper.GetUrl();

        var guid = url.Split('/').ToList().Single(x => x.Count(c => c == '-') == 4);

        var newUrl = url.Replace(guid, id);

        tabHelper.GoToUrl(newUrl);
    }
}