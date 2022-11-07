using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;

public class WorkExperienceProvidedPage : Raav2BasePage
{
    private By IframeBody => By.CssSelector(".mce-content-body ");
    protected override string PageTitle => "What work experience will the employer give the trainee?";
    private By WorkExperienceDescription => By.Id("WorkExperience_ifr");
    public WorkExperienceProvidedPage(ScenarioContext context, bool verifypage = true) : base(context, verifypage)
    {
            
    }

    public DurationPage EnterWorkExperience()
    {
        javaScriptHelper.SwitchFrameAndEnterText(WorkExperienceDescription, IframeBody, rAAV2DataHelper.WorkExperience);
        Continue();
        return new DurationPage(context);
    }
}