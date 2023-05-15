using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;

using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;

public class EsfaSignInPage : SignInBasePage
{
    protected override string PageTitle => "ESFA Sign in";

    public EsfaSignInPage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }
}


public class CheckEsfaSignInPage : CheckPageUsingShorterTimeOut
{
    protected override string PageTitle => "ESFA Sign in";

    protected override By Identifier => PageHeader;

    public CheckEsfaSignInPage(ScenarioContext context) : base(context) { }

    public override bool IsPageDisplayed() => checkPageInteractionHelper.WithoutImplicitWaits(() => VerifyPage());
}
