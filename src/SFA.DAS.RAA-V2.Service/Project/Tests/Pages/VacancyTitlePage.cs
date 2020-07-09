using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class VacancyTitlePage : BaseVacancyTitlePage
    {
        protected override string PageTitle => "What do you want to call this vacancy?";

        public VacancyTitlePage(ScenarioContext context) : base(context) { }
    }
}
