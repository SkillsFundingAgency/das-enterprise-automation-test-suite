using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public abstract class RAAV1BasePage : BasePage
    {
        #region Helpers and Context
        protected readonly ObjectContext objectContext;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly VacancyTitleDatahelper vacancyTitleDataHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly RAAV1RegistrationDataHelper rAAV1RegistrationDataHelper;
        protected readonly RAAV1DataHelper rAAV1DataHelper;
        protected readonly VacancyTitleDatahelper vacancyTitledataHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FAADataHelper faaDataHelper;
        protected readonly IFrameHelper frameHelper;
        protected readonly RAAV1Config rAAV1Config;
        protected RandomVacancyHelper randomVacancyHelper;
        #endregion


        public RAAV1BasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            objectContext = context.Get<ObjectContext>();
            tableRowHelper = context.Get<TableRowHelper>();
            vacancyTitleDataHelper = context.GetValue<VacancyTitleDatahelper>();
            rAAV1Config = context.GetRAAV1Config<RAAV1Config>();
            rAAV1RegistrationDataHelper = context.GetValue<RAAV1RegistrationDataHelper>();
            rAAV1DataHelper = context.GetValue<RAAV1DataHelper>();
            vacancyTitledataHelper = context.GetValue<VacancyTitleDatahelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            frameHelper = context.Get<IFrameHelper>();
            faaDataHelper = context.GetValue<FAADataHelper>();
            randomVacancyHelper = context.GetValue<RandomVacancyHelper>();

            if (verifypage) { VerifyPage(); }
        }
    }
}
