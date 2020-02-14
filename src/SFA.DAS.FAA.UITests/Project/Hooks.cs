using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;

namespace SFA.DAS.FAA.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public Hooks(ScenarioContext context)
        {
            _context = context;

            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();

            bool isCloneVacancy = _context.ScenarioInfo.Tags.Contains("clonevacancy");

            _context.Set(new VacancyTitleDatahelper(random, isCloneVacancy));

            _context.Set(new FAADataHelper(random));

            var regexHelper = _context.Get<RegexHelper>();
            
            var objectContext = _context.Get<ObjectContext>();

            var pageInteractionHelper = _context.Get<PageInteractionHelper>();

            _context.Set(new VacancyReferenceHelper(pageInteractionHelper, objectContext, regexHelper));
        }

        [BeforeScenario("apprenticeshipclosed", Order = 35)]

        public void IsApprenticeshipClosed()
        {
            _objectContext.SetApprenticeshipClosed();
        }
    }
}
