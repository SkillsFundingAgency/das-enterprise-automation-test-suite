using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.RAA.DataGenerator.Project.Config;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project
{
    [Binding]
    public class Hooks(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            bool isCloneVacancy = context.ScenarioInfo.Tags.Contains("clonevacancy");
            var pageInteractionHelper = context.Get<PageInteractionHelper>();

            context.Set(new VacancyTitleDatahelper(isCloneVacancy));

            context.Set(new FAADataHelper(context.Get<MailosaurUser>()));

            context.Set(new VacancyReferenceHelper(pageInteractionHelper, _objectContext));
        }

        [BeforeScenario(Order = 33)]
        public void LoginWithNewAccount()
        {
            var fAAnewcreds = context.Get<FAADataHelper>();
            var fAAConfig = context.GetFAAConfig<FAAConfig>();

            if (context.ScenarioInfo.Tags.Contains("faaloginwithnewcredentials"))
                _objectContext.SetFAALogin(fAAnewcreds.EmailId, fAAnewcreds.Password, fAAnewcreds.FirstName, fAAnewcreds.LastName);
            else
                _objectContext.SetFAALogin(fAAConfig.FAAUserName, fAAConfig.FAAPassword, fAAConfig.FAAFirstName, fAAConfig.FAALastName);
        }
    }
}
