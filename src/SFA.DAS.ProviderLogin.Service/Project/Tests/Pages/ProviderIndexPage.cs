using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.ProviderLogin.Service.Project.Helpers.CSSSelectors;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class ProviderIndexPage : IdamsLoginBasePage
{
    //pas login changes
    //protected override string PageTitle => "Apprenticeship service for training providers: sign in or register for an account";

    protected override string PageTitle => "Manage apprenticeships on behalf of employers";

    public ProviderIndexPage(ScenarioContext context) : base(context) { }

    public ProviderSignInPage StartNow()
    {
        formCompletionHelper.ClickElement(ProviderCSSSelectors.ProviderIndexStartSelector);

        ClickIfPirenIsDisplayed();

        return new ProviderSignInPage(context);
    }
}
