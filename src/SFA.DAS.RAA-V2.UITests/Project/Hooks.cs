using SFA.DAS.FAA.UITests.Project.Helpers;
using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;

        public Hooks(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario(Order = 33)]
        public void SetUpHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();

            var vacancyTitleDatahelper = _context.Get<VacancyTitleDatahelper>();

            _context.Set(new EmployerDataHelper(random, vacancyTitleDatahelper));
        }
    }
}
