using SFA.DAS.FAA.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAATestDataPrepSteps(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        [Given(@"the Applicant can apply for an advert in FAA using '(.*)', title as '(.*)'")]
        public void GivenTheApplicantCanApplyForAnAdvertInFAAUsing(string advertrefnum, string title)
        {
            _objectContext.SetVacancyReference(advertrefnum);

            context.Get<VacancyTitleDatahelper>().SetVacancyTitile(title);

            new FAAStepsHelper(context).ApplyForAVacancy("No", "No", "No");
        }
    }
}