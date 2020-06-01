using TechTalk.SpecFlow;

namespace SFA.DAS.Login.Service.Project.Tests.Pages
{
    public abstract class NavigateBase : LoginBasePage
    {
        protected NavigateBase(ScenarioContext context, string url) : base(context)
        {
            if (!(string.IsNullOrEmpty(url))) { tabHelper.GoToUrl(url); }
        }
    }
}