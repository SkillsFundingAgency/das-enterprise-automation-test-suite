using System.Threading;
using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages;

public abstract class TraineeshipRecruitBasePage : VerifyBasePage
{
    #region Helpers and Context
    protected readonly string Ukprn;
    protected readonly ProviderConfig ProviderConfig;
    private By ViewAllVacancy => By.CssSelector($"a[href='/{Ukprn}/vacancies/?filter=All']");
    #endregion

    protected sealed override By ContinueButton => By.CssSelector(".govuk-button--start");

    protected TraineeshipRecruitBasePage(ScenarioContext context) : base(context)
    {
        Ukprn = context.Get<ObjectContext>().Get("ukprn");
        ProviderConfig = context.GetProviderConfig<ProviderConfig>();
    }
}