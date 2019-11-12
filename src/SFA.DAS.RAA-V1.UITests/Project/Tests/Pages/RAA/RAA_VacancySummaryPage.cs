using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_VacancySummaryPage : RAA_VacancyLinkBasePage
    {
        protected override string PageTitle => dataHelper.VacancyTitle;

        #region Helpers and Context
        private readonly ObjectContext _objectContext;
        private RegexHelper _regexHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By VacancyStatus => By.CssSelector("#applicationTable .applicant span");


        public RAA_VacancySummaryPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _objectContext = context.Get<ObjectContext>();
            _regexHelper = context.Get<RegexHelper>();
        }

        public string GetVacancyStatus()
        {
            return _pageInteractionHelper.GetText(VacancyStatus);
        }

        public new void SetVacancyReference()
        {
            var vacref = _regexHelper.GetVacancyReferenceFromUrl(_pageInteractionHelper.GetUrl());
            _objectContext.SetVacancyReference(vacref);
        }
    }
}
