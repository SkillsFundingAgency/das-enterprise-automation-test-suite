using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public abstract class FAABasePage : BasePage
    {
        #region Helpers and Context
        protected readonly FAADataHelper faadataHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        protected readonly VacancyTitleDatahelper vacancytitledataHelper;
        protected readonly TabHelper tabHelper;
        protected readonly FAAConfig faaconfig;
        protected readonly RegexHelper regexHelper;
        #endregion

        protected FAABasePage(ScenarioContext context, bool verifyPage = true) : base(context)
        {
            objectContext = context.Get<ObjectContext>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            vacancytitledataHelper = context.Get<VacancyTitleDatahelper>();
            tabHelper = context.Get<TabHelper>();
            faaconfig = context.GetFAAConfig<FAAConfig>();
            faadataHelper = context.Get<FAADataHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            regexHelper = context.Get<RegexHelper>();
            if (verifyPage) VerifyPage();
        }
    }
}