using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Helpers;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public abstract class RegistrationBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly RegistrationConfig config;
        protected readonly ObjectContext objectContext;
        protected readonly RegistrationDataHelper registrationDataHelper;
        private readonly ScenarioContext _context;
        #endregion

        protected RegistrationBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            config = context.GetRegistrationConfig<RegistrationConfig>();
            objectContext = context.Get<ObjectContext>();
            registrationDataHelper = context.Get<RegistrationDataHelper>();
        }

        public HomePage GoToHomePage() => new HomePage(_context, true);

        public HomePage ClickBackLink()
        {
            NavigateBack();
            return new HomePage(_context);
        }
    }
}
