using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages.ConfirmSurveySentPage;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class CheckYourAnswerPage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "Check your details before they’re sent to DfE";
        private static By ChangeNameButton => By.CssSelector("#change-name-link");
        private static By ChangeDoBButton => By.CssSelector("#change-dob-link");
        private static By ChangeTelButton => By.CssSelector("#change-tel-link");
        private static By ChangePostcodeButton => By.CssSelector("#change-postcode-link");
        private static By ChangeSchoolButton => By.CssSelector("#change-school-link");
        private static By ChangeIndustryButton => By.CssSelector("#change-industry-link");

        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public ApplicantSurveySummitedPage AcceptAndSubmitForm()
        {
            formCompletionHelper.ClickElement(ContinueButton);
            return new ApplicantSurveySummitedPage(context);
        }
        public WhatsYourNamePage ChangeName()
        {
            formCompletionHelper.ClickElement(ChangeNameButton);
            return new WhatsYourNamePage(context);
        }
        public DateOfBirthPage ChangeDoB()
        {
            formCompletionHelper.ClickElement(ChangeDoBButton);
            return new DateOfBirthPage(context);
        }
        public TelephonePage ChangeTel()
        {
            formCompletionHelper.ClickElement(ChangeTelButton);
            return new TelephonePage(context);
        }
        public PostcodePage ChangePostcode()
        {
            formCompletionHelper.ClickElement(ChangePostcodeButton);
            return new PostcodePage(context);
        }

        public SchoolCollegePage ChangeSchool()
        {
            formCompletionHelper.ClickElement(ChangeSchoolButton);
            return new SchoolCollegePage(context);
        }
        public AreasOfWorkInterestPage ChangeIndustry()
        {
            formCompletionHelper.ClickElement(ChangeIndustryButton);
            return new AreasOfWorkInterestPage(context);
        }
    }
}
