using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages;

public abstract class TraineeshipRecruitBasePage : VerifyBasePage
{
    #region Helpers and Context
    protected readonly string ukprn;
    protected readonly ProviderConfig providerConfig;
    private By ViewAllVacancy => By.CssSelector($"a[href='/{ukprn}/vacancies/?filter=All']");
    #endregion

    protected sealed override By ContinueButton => By.CssSelector(".govuk-button--start");

    protected TraineeshipRecruitBasePage(ScenarioContext context) : base(context)
    {
        ukprn = context.Get<ObjectContext>().Get("ukprn");
        providerConfig = context.GetProviderConfig<ProviderConfig>();
        //context.TryGetValue(out dataHelper);
        //VerifyPage();
    }
    
    public ViewAllVacancyPage GoToViewAllVacancyPage()
    {
        if (pageInteractionHelper.IsElementDisplayed(ViewAllVacancy))
        {
            formCompletionHelper.Click(ViewAllVacancy);    
        }

        return new ViewAllVacancyPage(context);
    }
}