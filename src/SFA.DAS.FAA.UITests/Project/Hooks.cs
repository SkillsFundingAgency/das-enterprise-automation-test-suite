using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
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
            var regexHelper = _context.Get<RegexHelper>();
            var pageInteractionHelper = _context.Get<PageInteractionHelper>();

            _context.Set(new VacancyTitleDatahelper(random, isCloneVacancy));
            _context.Set(new FAADataHelper(random));
            _context.Set(new VacancyReferenceHelper(pageInteractionHelper, _objectContext, regexHelper));
        }

        [BeforeScenario(Order = 33)]
        public void LoginWithNewAccount()
        {
            var fAAnewcreds = _context.Get<FAADataHelper>();
            var fAAConfig = _context.GetFAAConfig<FAAConfig>();

            if (_context.ScenarioInfo.Tags.Contains("FAALoginNewCredentials"))
                _objectContext.SetFAALogin(fAAnewcreds.EmailId, fAAnewcreds.Password, fAAnewcreds.FirstName, fAAnewcreds.LastName);
            else
                _objectContext.SetFAALogin(fAAConfig.FAAUserName, fAAConfig.FAAPassword, fAAConfig.FAAFirstName, fAAConfig.FAALastName);
        }
    }
}
