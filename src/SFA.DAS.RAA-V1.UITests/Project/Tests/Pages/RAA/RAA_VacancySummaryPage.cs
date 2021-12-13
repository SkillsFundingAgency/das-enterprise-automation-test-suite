using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_VacancySummaryPage : RAA_VacancyLinkBasePage
    {
        protected override string PageTitle => vacancyTitledataHelper.VacancyTitle;

        private By VacancyStatus => By.CssSelector("#applicationTable .applicant span");

        public RAA_VacancySummaryPage(ScenarioContext context) : base(context) { }

        public string GetVacancyStatus() => pageInteractionHelper.GetText(VacancyStatus);

        public new void SetVacancyReference() => objectContext.SetVacancyReference(RegexHelper.GetVacancyReferenceFromUrl(GetUrl()));

        public RAA_ApplicationPreviewPage ViewApplication()
        {
            formCompletionHelper.ClickLinkByText("View application");
            return new RAA_ApplicationPreviewPage(context);
        }

        public RAA_VacancyApplicationPage AnonymousView()
        {
            formCompletionHelper.ClickLinkByText("Anonymous view");
            return new RAA_VacancyApplicationPage(context);
        }
    }
}