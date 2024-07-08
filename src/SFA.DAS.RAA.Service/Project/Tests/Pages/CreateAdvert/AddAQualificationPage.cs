using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert
{
    public class AddAQualificationPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Add a qualification";
        private static By QualificationType => By.Name("QualificationType");

        private static By Subject => By.CssSelector("#Subject");

        private static By Grade => By.CssSelector("#Grade");

        public ConfirmQualificationsPage EnterQualifications()
        {
            formCompletionHelper.SelectFromDropDownByText(QualificationType, "A Level");
            formCompletionHelper.EnterText(Subject, rAADataHelper.DesiredQualificationsSubject);
            formCompletionHelper.EnterText(Grade, RAA.DataGenerator.RAADataHelper.DesiredQualificationsGrade);
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioLabels)));
            Continue();
            return new ConfirmQualificationsPage(context);
        }
    }
}
