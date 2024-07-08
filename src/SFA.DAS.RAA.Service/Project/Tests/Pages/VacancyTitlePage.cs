using SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class VacancyTitlePage(ScenarioContext context) : BaseVacancyTitlePage(context)
    {
        protected override string PageTitle => "What do you want to call this vacancy?";
    }
}
