using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public abstract class InterimProviderBasePage : Navigate
{
    #region Helpers and Context
    protected readonly string ukprn;
    #endregion

    protected static By NotificationSettingsLink => By.LinkText("Notification settings");
    protected static By OrganisationsAndAgreementsLink => By.LinkText("Organisations and agreements");

    protected override By AcceptCookieButton => By.CssSelector(".das-cookie-banner__button-accept");

    public InterimProviderBasePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
    {
        ukprn = context.Get<ObjectContext>().GetUkprn();
        VerifyPage();
    }
}
