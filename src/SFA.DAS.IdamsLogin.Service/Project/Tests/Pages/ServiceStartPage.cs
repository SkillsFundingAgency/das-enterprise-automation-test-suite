using OpenQA.Selenium;
using SFA.DAS.IdamsLogin.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;

public class ServiceStartPage : IdamsLoginBasePage
{
    protected override string PageTitle => "ESFA admin services";

    private static By StartNowCssSelector => IdamsPageSelector.StartNowButton;

    public ServiceStartPage(ScenarioContext context) : base(context) { }

    public PreProdDIGBEADFSPage StartNow()
    {
        ClickStartNowButton();
        return new PreProdDIGBEADFSPage(context);
    }

    public void ClickStartNowButton() => formCompletionHelper.ClickElement(StartNowCssSelector);

}
