//using OpenQA.Selenium;
//using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
//using TechTalk.SpecFlow;

//namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
//{
//    public class EditPersonalDetailsPage : AddAndEditApprenticeDetailsBasePage
//    {
//        protected override string PageTitle => "Edit personal details";

//        private static By SaveAndContinueButton => By.CssSelector("#main-content .govuk-button");

//        public EditPersonalDetailsPage(ScenarioContext context) : base(context)
//        {
//        }

//        public EditTrainingDetailsPage ContinueToAddTrainingDetailsPage()
//        {
//            formCompletionHelper.ClickElement(SaveAndContinueButton);
//            return new EditTrainingDetailsPage(context);
//        }
//    }
//}