using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Login.Service.Project.Tests.Pages
{
    public abstract class NavigateBase : BasePage
    {
        protected NavigateBase(ScenarioContext context, string url) : base(context)
        {
            if (!(string.IsNullOrEmpty(url))) tabHelper.GoToUrl(url); 
        }
    }
}