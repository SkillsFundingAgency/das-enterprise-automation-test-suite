using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class QualificationsPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "What qualifications would you like the applicant to have?";

        private By QualificationType => By.CssSelector("#QualificationType");

        private By Subject => By.CssSelector("#Subject");

        private By Grade => By.CssSelector("#Grade");
       
        public QualificationsPage(ScenarioContext context) : base(context) { }

        public ConfirmQualificationsPage EnterQualifications()
        {
            formCompletionHelper.SelectFromDropDownByText(QualificationType, "A Level or equivalent");
            formCompletionHelper.EnterText(Subject, rAAV2DataHelper.DesiredQualificationsSubject);
            formCompletionHelper.EnterText(Grade, rAAV2DataHelper.DesiredQualificationsGrade);
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioLabels)));
            Continue();
            return new ConfirmQualificationsPage(_context);
        }

    }
}
