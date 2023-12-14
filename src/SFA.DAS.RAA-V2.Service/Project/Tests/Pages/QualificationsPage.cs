using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class QualificationsPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => "What qualifications would you like the applicant to have?";

        private static By QualificationType => By.CssSelector("#QualificationType");

        private static By Subject => By.CssSelector("#Subject");

        private static By Grade => By.CssSelector("#Grade");

        public ConfirmQualificationsPage EnterQualifications()
        {
            formCompletionHelper.SelectFromDropDownByText(QualificationType, "A Level or equivalent");
            formCompletionHelper.EnterText(Subject, rAAV2DataHelper.DesiredQualificationsSubject);
            formCompletionHelper.EnterText(Grade, RAA.DataGenerator.RAAV2DataHelper.DesiredQualificationsGrade);
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioLabels)));
            Continue();
            return new ConfirmQualificationsPage(context);
        }

    }
}
