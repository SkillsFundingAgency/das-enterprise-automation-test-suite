using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CovidRedundancy.UITests.Project.Helpers
{
    public abstract class CovidRedundancyBasePage : BasePage
    { 
    protected override By PageHeader => By.TagName("h1");
    protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

    #region Helpers and Context
    protected readonly ObjectContext objectContext;
    protected readonly PageInteractionHelper pageInteractionHelper;
    protected readonly FormCompletionHelper formCompletionHelper;
    protected readonly CRConfig cRConfig;
    #endregion

    public CovidRedundancyBasePage(ScenarioContext context) : base(context)
    {
        objectContext = context.Get<ObjectContext>();
        formCompletionHelper = context.Get<FormCompletionHelper>();
        pageInteractionHelper = context.Get<PageInteractionHelper>();
        cRConfig = context.GetCRConfig<CRConfig>();
    }
  }
}
