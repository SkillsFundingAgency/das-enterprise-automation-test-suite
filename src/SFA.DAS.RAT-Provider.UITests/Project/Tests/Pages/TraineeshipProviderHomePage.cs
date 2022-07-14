using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages;

public class TraineeshipProviderHomePage : ProviderHomePage
{
    
    protected static By RecruitTraineesLink => By.LinkText("Recruit trainees");
    private By ViewAllVacancy => By.CssSelector($"a[href='/{ukprn}/vacancies/?filter=All']");
    #region Helpers and Context
    private readonly SearchVacancyPageHelper _searchVacancyPageHelper;
    #endregion

    public TraineeshipProviderHomePage(ScenarioContext context, bool navigate = false) :base(context) {}
    

    public TraineeshipRecruitHomePage GoToTraineeshipHomePage()
    {
        formCompletionHelper.ClickElement(RecruitTraineesLink);
        
        //ClickIfPirenIsDisplayed();
        
        return new TraineeshipRecruitHomePage(context);
    }
    //public ManageRecruitPage SearchVacancyByVacancyReference() => _searchVacancyPageHelper.SearchVacancyByVacancyReference();

    public ProviderVacancySearchResultPage SearchVacancy() => _searchVacancyPageHelper.SearchProviderVacancy();

    public ViewAllVacancyPage GoToViewAllVacancyPage()
    {
        formCompletionHelper.Click(ViewAllVacancy);
        return new ViewAllVacancyPage(context);
    }
    public ReferVacancyPage SearchReferAdvertTitle()
    {
        var vacancyPage = _searchVacancyPageHelper.SearchReferVacancy();

        //vacancyPage.NavigateToAdvertTitle();

        return new ReferVacancyPage(context);
    }
}