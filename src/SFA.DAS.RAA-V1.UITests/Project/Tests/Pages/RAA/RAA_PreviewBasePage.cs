using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public abstract class RAA_PreviewBasePage : RAA_VacancyReferenceBasePage
    {
        protected override By VacancyReferenceNumber => By.CssSelector("#vacancy-reference-id");

        public RAA_PreviewBasePage(ScenarioContext context) : base(context) { }

        public RAA_VacancyReferencePage ClickSubmitForApprovalButton()
        {
            formCompletionHelper.ClickButtonByText("Submit for approval");
            return new RAA_VacancyReferencePage(_context);
        }
    }
}
