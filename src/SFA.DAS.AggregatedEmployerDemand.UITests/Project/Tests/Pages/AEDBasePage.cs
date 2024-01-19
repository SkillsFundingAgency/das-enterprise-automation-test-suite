using SFA.DAS.ProviderLogin.Service.Project;

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
    }
}
