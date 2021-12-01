using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public abstract class RAAV1BasePage : BasePage
    {
        #region Helpers and Context
        protected readonly VacancyTitleDatahelper vacancyTitleDataHelper;
        protected readonly RAAV1RegistrationDataHelper rAAV1RegistrationDataHelper;
        protected readonly RAAV1DataHelper rAAV1DataHelper;
        protected readonly VacancyTitleDatahelper vacancyTitledataHelper;
        protected readonly FAADataHelper faaDataHelper;
        protected readonly RAAV1Config rAAV1Config;
        protected RandomVacancyHelper randomVacancyHelper;
        #endregion


        public RAAV1BasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            vacancyTitleDataHelper = context.GetValue<VacancyTitleDatahelper>();
            rAAV1Config = context.GetRAAV1Config<RAAV1Config>();
            rAAV1RegistrationDataHelper = context.GetValue<RAAV1RegistrationDataHelper>();
            rAAV1DataHelper = context.GetValue<RAAV1DataHelper>();
            vacancyTitledataHelper = context.GetValue<VacancyTitleDatahelper>();
            faaDataHelper = context.GetValue<FAADataHelper>();
            randomVacancyHelper = context.GetValue<RandomVacancyHelper>();

            if (verifypage) { VerifyPage(); }
        }
    }
}
