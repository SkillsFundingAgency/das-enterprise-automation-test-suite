using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project
{
    [Binding, Scope(Tag = "roatpadmin")]
    public class RoatpAdminHooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private RoatpAdminUkprnDataHelpers _adminUkprnDataHelpers;

        public RoatpAdminHooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            _adminUkprnDataHelpers = new RoatpAdminUkprnDataHelpers();
            _context.Set(_adminUkprnDataHelpers);

            _context.Set(new RoatpAdminDataHelpers(_context.Get<RandomDataGenerator>()));
        }

        [BeforeScenario(Order = 33)]
        public void GetRoatpAdminData()
        {
            // every scenario (admin) should only have one tag which starts with rpad, which is mapped to the test data.
            var tag = _context.ScenarioInfo.Tags.ToList().Single(x => x.StartsWith("rpad"));
            var (providername, ukprn) = _adminUkprnDataHelpers.GetRoatpAdminData(tag);

            _objectContext.SetProviderName(providername);
            _objectContext.SetUkprn(ukprn);
        }
    }
}
