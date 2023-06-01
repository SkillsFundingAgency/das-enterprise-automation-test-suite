using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;


public static class IdamsPageSelector
{
    internal static By Access1Staff => By.XPath("//span[contains(text(),'Access1 Staff')]");
}

public class CheckIdamsPage: CheckPageUsingShorterTimeOut
{
    protected override string PageTitle { get; }

    protected override By Identifier => IdamsPageSelector.Access1Staff;

    public CheckIdamsPage(ScenarioContext context) : base(context) { }
}

public class IdamsPage : IdamsLoginBasePage
{
    protected override string PageTitle => "Sign in using your account on:";

    protected override bool CanAnalyzePage => false;

    public IdamsPage(ScenarioContext context) : base(context, false) => VerifyPageAfterRefresh(PireanPreprod);

    public void LoginToAccess1Staff() => formCompletionHelper.Click(IdamsPageSelector.Access1Staff);
}
