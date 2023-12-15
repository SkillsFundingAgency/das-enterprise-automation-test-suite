using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class SuccessfullyReservedFundingPage(ScenarioContext context) : ReservationIdBasePage(context)
    {
        protected override string PageTitle => "You have successfully reserved funding for apprenticeship training";
        protected override By ContinueButton => By.CssSelector("main button");

        private static By AddApprenticeRadioButton => By.CssSelector("label[for=WhatsNext-add]");

        public DynamicHomePages GoToDynamicHomePage()
        {
            SelectRadioOptionByForAttribute("WhatsNext-home");
            formCompletionHelper.ClickElement(ContinueButton);
            return new DynamicHomePages(context);
        }

        internal AddAnApprenitcePage AddApprentice()
        {
            ChooseToAddApprenticeRadioButton();
            Continue();
            return new AddAnApprenitcePage(context);
        }

        internal SelectStandardPage AddAnotherApprentice()
        {
            ChooseToAddApprenticeRadioButton();
            Continue();
            return new SelectStandardPage(context);
        }

        private void ChooseToAddApprenticeRadioButton() => formCompletionHelper.ClickElement(AddApprenticeRadioButton);
    }
}