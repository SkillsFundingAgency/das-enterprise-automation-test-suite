using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public abstract class RAAV1BasePage : BasePage
    {
        #region Helpers and Context
        protected readonly TableRowHelper tableRowHelper;
        protected readonly VacancyTitleDatahelper vacancyTitleDataHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly RAAV1RegistrationDataHelper rAAV1RegistrationDataHelper;
        protected readonly RAAV1DataHelper rAAV1DataHelper;
        protected readonly VacancyTitleDatahelper vacancyTitledataHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FAADataHelper faaDataHelper;
        protected readonly TabHelper tabHelper;
        protected readonly RAAV1Config rAAV1Config;
        #endregion


        public RAAV1BasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            tableRowHelper = context.Get<TableRowHelper>();
            vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();
            rAAV1Config = context.GetRAAV1Config<RAAV1Config>();
            rAAV1RegistrationDataHelper = context.Get<RAAV1RegistrationDataHelper>();
            rAAV1DataHelper = context.Get<RAAV1DataHelper>();
            vacancyTitledataHelper = context.Get<VacancyTitleDatahelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            tabHelper = context.Get<TabHelper>();
            faaDataHelper = context.Get<FAADataHelper>();

            if (verifypage) { VerifyPage(); }
        }
    }
}
