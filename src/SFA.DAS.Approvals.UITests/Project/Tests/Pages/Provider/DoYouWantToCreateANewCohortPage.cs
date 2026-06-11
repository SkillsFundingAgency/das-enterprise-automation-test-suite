using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class DoYouWantToCreateANewCohortPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Do you want to create a new cohort?";
        private static By AddToAnExistingCohortRadio => By.XPath("//label[contains(text(),'No, add to an existing cohort')]");
        private static By CreateANewCohort => By.XPath("//label[contains(text(),'Yes, create a new cohort')]");
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        public ProviderChooseACohortPage SelectOptionAddToAnExistingCohort()
        {
            javaScriptHelper.ClickElement(AddToAnExistingCohortRadio);
            Continue();
            return new ProviderChooseACohortPage(context);
        }

        public ProviderChooseAnEmployerNonLevyPage SelectOptionCreateNewCohort()
        {
            javaScriptHelper.ClickElement(CreateANewCohort);
            Continue();
            return new ProviderChooseAnEmployerNonLevyPage(context);
        }

        public bool IsCreateANewCohortOptionDisplayed() => pageInteractionHelper.IsElementDisplayed(CreateANewCohort);

        public bool IsAddToAnExistingCohortOptionDisplayed() => pageInteractionHelper.IsElementDisplayed(AddToAnExistingCohortRadio);
    }
}