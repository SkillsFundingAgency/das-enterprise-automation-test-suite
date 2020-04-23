using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Helpers;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public abstract class ProviderLeadRegistrationBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly RegistrationConfig config;
        protected readonly ObjectContext objectContext;
        protected readonly RegistrationDataHelper registrationDataHelper;
        #endregion

        protected ProviderLeadRegistrationBasePage(ScenarioContext context) : base(context)
        {
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            config = context.GetRegistrationConfig<RegistrationConfig>();
            objectContext = context.Get<ObjectContext>();
            registrationDataHelper = context.Get<RegistrationDataHelper>();
        }
    }
}
