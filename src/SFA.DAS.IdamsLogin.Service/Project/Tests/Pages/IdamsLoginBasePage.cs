using OpenQA.Selenium;
using SFA.DAS.IdamsLogin.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;

public abstract class IdamsLoginBasePage : VerifyBasePage
{
    protected static By PireanPreprod => Selectors.PireanPreprod;

    protected IdamsLoginBasePage(ScenarioContext context, bool verifypage = true): base(context)
    {
        if (verifypage) VerifyPage();
    }

    public void LoginToPireanPreprod() => formCompletionHelper.Click(PireanPreprod);

    protected void ClickIfPirenIsDisplayed()
    {
        if (pageInteractionHelper.IsElementDisplayed(PireanPreprod))
            LoginToPireanPreprod();
    }
}
