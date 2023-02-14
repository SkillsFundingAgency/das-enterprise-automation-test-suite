using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

public class ProviderRoutePage : RoatpAdminBasePage
{
    protected override string PageTitle => $"Choose a provider route for {objectContext.GetProviderName()}";

    protected override By ContinueButton => By.CssSelector(".govuk-button[value='Continue']");

    public ProviderRoutePage(ScenarioContext context) : base(context) { }

    public TypeOrganisationsPage SubmitProviderType(string providerType)
    {
        SelectRadioOptionByText(providerType);
        Continue();
        return new TypeOrganisationsPage(context);
    }
}
