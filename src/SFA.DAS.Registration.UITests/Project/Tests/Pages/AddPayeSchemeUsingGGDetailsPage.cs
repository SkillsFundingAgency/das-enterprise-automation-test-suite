using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public  class AddPayeSchemeUsingGGDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Add a PAYE scheme using your Government Gateway details";
        protected override By ContinueButton => By.Id("agree_and_continue");
        private By BackButton => By.ClassName("govuk-back-link");

        public AddPayeSchemeUsingGGDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public GgSignInPage AgreeAndContinue()
        {
            formCompletionHelper.ClickElement(ContinueButton);
            return new GgSignInPage(context);
        }

        public TheseDetailsAreAlreadyInUsePage ClickBackButton()
        {
            formCompletionHelper.ClickElement(BackButton);
            return new TheseDetailsAreAlreadyInUsePage(context);
        }

    }
}
