using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator.Project.Config;

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
            bool isCloneVacancy = _context.ScenarioInfo.Tags.Contains("clonevacancy");
            var pageInteractionHelper = _context.Get<PageInteractionHelper>();

            _context.Set(new VacancyTitleDatahelper(isCloneVacancy));
            _context.Set(new FAADataHelper());
            _context.Set(new VacancyReferenceHelper(pageInteractionHelper, _objectContext));
        }

        [BeforeScenario(Order = 33)]
        public void LoginWithNewAccount()
        {
            var fAAnewcreds = _context.Get<FAADataHelper>();
            var fAAConfig = _context.GetFAAConfig<FAAConfig>();

            if (_context.ScenarioInfo.Tags.Contains("faaloginwithnewcredentials"))
                _objectContext.SetFAALogin(fAAnewcreds.EmailId, fAAnewcreds.Password, fAAnewcreds.FirstName, fAAnewcreds.LastName);
            else
                _objectContext.SetFAALogin(fAAConfig.FAAUserName, fAAConfig.FAAPassword, fAAConfig.FAAFirstName, fAAConfig.FAALastName);
        }
    }
}
