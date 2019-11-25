using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public abstract class RAA_VacancyReferenceBasePage : RAA_HeaderSectionBasePage
    {
        #region Helpers and Context
        private RegexHelper _regexHelper;
        private ObjectContext _objectContext;
        protected readonly PageInteractionHelper pageInteractionHelper;
        #endregion

        protected virtual By VacancyReferenceNumber { get; set; }

        public RAA_VacancyReferenceBasePage(ScenarioContext context) : base(context)
        {
            _regexHelper = context.Get<RegexHelper>();
            _objectContext = context.Get<ObjectContext>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public void SetVacancyReference()
        {
            var referenceNumber = pageInteractionHelper.GetText(VacancyReferenceNumber);

            _objectContext.SetVacancyReference(_regexHelper.GetVacancyReference(referenceNumber));
        }
    }
}
