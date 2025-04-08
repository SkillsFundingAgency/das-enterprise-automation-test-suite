using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.Service.Project.Helpers;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert;
using SFA.DAS.RAAProvider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Helpers
{
    public class ProviderCreateDraftAdvertStepsHelper(ScenarioContext context) : ProviderCreateVacancyStepsHelper(context)
    {
        internal VacancyReferencePage SubmitDraftAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            CheckAndSubmitAdvert(CompleteAboutTheEmployer(createAdvertPage).EnterAdditionalQuestionsForApplicants().CompleteAllAdditionalQuestionsForApplicants(true, true));

        protected CreateAnApprenticeshipAdvertOrVacancyPage CompleteAboutTheEmployer(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            AboutTheEmployer(SkillsAndQualifications(createAdvertPage), string.Empty, true, true);
    }
}
