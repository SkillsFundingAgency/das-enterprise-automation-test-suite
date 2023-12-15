using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;

public class WorkExperienceProvidedPage(ScenarioContext context, bool verifypage = true) : Raav2BasePage(context, verifypage)
{
    private static By IframeBody => By.CssSelector(".mce-content-body ");
    protected override string PageTitle => "What work experience will the employer give the trainee?";
    private static By WorkExperienceDescription => By.Id("WorkExperience_ifr");

    public DurationPage EnterWorkExperience()
    {
        javaScriptHelper.SwitchFrameAndEnterText(WorkExperienceDescription, IframeBody, rAAV2DataHelper.WorkExperience);
        Continue();
        return new DurationPage(context);
    }
}