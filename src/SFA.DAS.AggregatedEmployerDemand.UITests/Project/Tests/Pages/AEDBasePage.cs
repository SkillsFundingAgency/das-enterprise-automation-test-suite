using FluentAssertions;
using Selenium.Axe;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.IO;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages;

public abstract class AedBasePage : VerifyBasePage
{
    #region Helpers and Context
    protected readonly ProviderConfig providerConfig;
    protected readonly AedDataHelper dataHelper;
    #endregion

    protected sealed override By ContinueButton => By.CssSelector("#continue");

    protected AedBasePage(ScenarioContext context) : base(context)
    {
        providerConfig = context.GetProviderConfig<ProviderConfig>();
        
        context.TryGetValue(out dataHelper);
        
        VerifyPage();

        AnalyzePage();
    }

    private void AnalyzePage()
    {
        string fileName = $"{RegexHelper.TrimAnySpace(PageTitle)}_{_screenShotTitleGenerator.GetTitle()}.html";

        TestAttachmentHelper.AddTestAttachment(_directory, fileName, (x) => 
        {
            IWebDriver webDriver = context.GetWebDriver();

            AxeResult axeResult = new AxeBuilder(webDriver).Analyze();

            webDriver.CreateAxeHtmlReport(axeResult, x);
        });
    }
}
