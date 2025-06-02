using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gherkin.Ast;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;

public class ProviderPrivacyPage(ScenarioContext context) : ApprovalsBasePage(context)
{
    protected override string PageTitle => "Privacy";
    protected static By ProviderHomeLink => By.LinkText("Home");

    public ApprovalsProviderHomePage GoToProviderHomePage()
    {
        formCompletionHelper.ClickElement(ProviderHomeLink);
        return new ApprovalsProviderHomePage(context);
    }
}
