using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public abstract class RAA_VacancyReferenceBasePage : RAA_HeaderSectionBasePage
    {
        #region Helpers and Context
        protected readonly PageInteractionHelper pageInteractionHelper;
        private readonly VacancyReferenceHelper _vacancyReferenceHelper;
        #endregion

        protected virtual By VacancyReferenceNumber { get; set; }

        public RAA_VacancyReferenceBasePage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            _vacancyReferenceHelper = context.Get<VacancyReferenceHelper>();
        }

        public void SetVacancyReference()
        {
            _vacancyReferenceHelper.SetVacancyReference(VacancyReferenceNumber);
        }
    }
}
