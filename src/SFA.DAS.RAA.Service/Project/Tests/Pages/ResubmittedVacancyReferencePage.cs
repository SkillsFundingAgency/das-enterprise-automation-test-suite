using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ResubmittedVacancyReferencePage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Advert resubmitted for approval";
    }
}
