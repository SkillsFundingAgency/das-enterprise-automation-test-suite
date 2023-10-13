using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.ProviderLogin.Service.Project.Helpers.CSSSelectors;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class ProviderIndexPage : IdamsLoginBasePage
{
    protected override string PageTitle => "Apprenticeship service for training providers: sign in or register for an account";

    public ProviderIndexPage(ScenarioContext context) : base(context) { }

    public void StartNow() => formCompletionHelper.ClickElement(ProviderCSSSelectors.ProviderIndexStartSelector);
}
