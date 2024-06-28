using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project.Config;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public abstract class FAABasePage : VerifyBasePage
    {
        #region Helpers and Context
        protected readonly FAADataHelper faaDataHelper;
        protected readonly VacancyTitleDatahelper vacancyTitleDataHelper;
        protected readonly FAAUserConfig faaConfig;
        #endregion

        protected FAABasePage(ScenarioContext context, bool verifyPage = true) : base(context)
        {
            vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();
            faaConfig = context.GetFAAConfig<FAAUserConfig>();
            faaDataHelper = context.Get<FAADataHelper>();
            if (verifyPage) VerifyPage();
        }
    }
}