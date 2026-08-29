using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public partial class FullyConfirmedOverviewPage : ApprenticeOverviewPage
    {
        protected override string PageTitle => "Confirm my apprenticeship details";
        private static By RolesSectionHeaderLink => By.XPath("//a[contains(text(),'Roles and responsibilities')]");
        private static By RolesSectionSubText => By.XPath("//a[contains(text(),'Roles and responsibilities')]/..//following-sibling::p");
        private static By HYAWDSectionHeaderLink => By.XPath("//a[contains(text(),'How your apprenticeship will be delivered')]");
        private static By HYAWDSectionSubText => By.XPath("//a[contains(text(),'How your apprenticeship will be delivered')]/..//following-sibling::p");
        private static By CourseName => By.CssSelector("span.govuk-caption-m");
        private static By CurrentEmployer => By.XPath("//th[text()='Current employer']/following-sibling::td");
        private static By TrainingProvider => By.XPath("//th[text()='Training provider']/following-sibling::td");
        private static By JobEndDate => By.XPath("//th[text()='Current job end date']/following-sibling::td");
        private static By ConfirmDetailsTabLink => By.LinkText("Confirm my apprenticeship details");

        public FullyConfirmedOverviewPage(ScenarioContext context, bool verifypage = true) : base(context, verifypage: verifypage, verifyserviceheader: false, verifyfooterlinks: false)
        {
            By PageTitleHeading = By.XPath("//h1[contains(text(), 'Confirm my apprenticeship details')]");

            if (verifypage)
            {
                PageInteractionHelper.WaitForElementToAppear(PageTitleHeading, 30);

                MultipleVerifyPage(
                [
                    () => VerifyPage(PageTitleHeading, PageTitle),
                    () => VerifyPage(() => pageInteractionHelper.FindElement(CourseName), objectContext.GetExpectedTrainingTitles()),
                    () => VerifyPage(RolesSectionHeaderLink),
                    () => VerifyPage(RolesSectionSubText, OverviewPageHelper.FullyConfirmedOverviewRolesSubText),
                    () => VerifyPage(HYAWDSectionHeaderLink),
                    () => VerifyPage(HYAWDSectionSubText, OverviewPageHelper.FullyConfirmedOverviewHYAWDSubText)
                ]);
            }
        }

        public void ClickConfirmMyDetailsTab()
        {
            PageInteractionHelper.WaitForElementToAppear(ConfirmDetailsTabLink, 10);

            formCompletionHelper.Click(ConfirmDetailsTabLink);
        }
        public AlreadyConfirmedRolesAndResponsibilitiesPage GoToConfirmedRolesPage()
        {
            formCompletionHelper.Click(RolesSectionHeaderLink);
            return new AlreadyConfirmedRolesAndResponsibilitiesPage(context);
        }

        public AlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage GoToConfirmedHowYourApprenticeshipWillBeDeliveredPage()
        {
            formCompletionHelper.Click(HYAWDSectionHeaderLink);
            return new AlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage(context);
        }

        public string GetEmployer() => pageInteractionHelper.GetText(CurrentEmployer);

        public string GetTrainingProvider() => pageInteractionHelper.GetText(TrainingProvider);

        public string GetPortableApprenticeshipCurrentJobEndDateInfo() => pageInteractionHelper.GetText(JobEndDate);
    }
}
