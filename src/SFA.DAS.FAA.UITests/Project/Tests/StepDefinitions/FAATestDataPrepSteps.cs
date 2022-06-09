using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FAA.UITests.Project.Helpers;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAATestDataPrepSteps
    {
        private readonly ObjectContext _objectContext;

        private readonly ScenarioContext _context;

        public FAATestDataPrepSteps(ScenarioContext context)
        {
            _context = context;

            _objectContext = context.Get<ObjectContext>();
        }

        [Given(@"the Applicant can apply for an advert in FAA using '(.*)', title as '(.*)'")]
        public void GivenTheApplicantCanApplyForAnAdvertInFAAUsing(string advertrefnum, string title)
        {
            _objectContext.SetVacancyReference(advertrefnum);

            _context.Get<VacancyTitleDatahelper>().SetVacancyTitile(title);

            new FAAStepsHelper(_context).ApplyForAVacancy("No", "No", "No");
        }
    }
}