using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using System;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public abstract class FAABasePage : BasePage
    {
        #region Helpers and Context
        protected readonly FAADataHelper _faadataHelper;
        protected readonly FormCompletionHelper _formCompletionHelper;
        protected readonly PageInteractionHelper _pageInteractionHelper;
        protected readonly ObjectContext _objectContext;
        protected readonly VacancyTitleDatahelper _vacancytitledataHelper;
        protected readonly TabHelper _tabHelper;
        protected readonly FAAConfig _config;
        protected readonly RegexHelper _regexHelper;
        #endregion

        protected FAABasePage(ScenarioContext context, bool verifyPage = true) : base(context)
        {
            _objectContext = context.Get<ObjectContext>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _vacancytitledataHelper = context.Get<VacancyTitleDatahelper>();
            _tabHelper = context.Get<TabHelper>();
            _config = context.GetFAAConfig<FAAConfig>();
            _faadataHelper = context.Get<FAADataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _regexHelper = context.Get<RegexHelper>();
            if (verifyPage) VerifyPage();
        }
    }
}