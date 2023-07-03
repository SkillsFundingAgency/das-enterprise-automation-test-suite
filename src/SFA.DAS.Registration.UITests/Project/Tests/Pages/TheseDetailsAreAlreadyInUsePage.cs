using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class TheseDetailsAreAlreadyInUsePage : RegistrationBasePage
    {
        protected override string PageTitle => "These details are already in use";
        
        #region Locators
        protected override By ContinueButton => By.Id("search_again");
        #endregion

        public TheseDetailsAreAlreadyInUsePage(ScenarioContext context) : base(context) => VerifyPage();

        public AddPayeSchemeUsingGGDetailsPage CickUseDifferentDetailsButtonInTheseDetailsAreAlreadyInUsePage()
        {
            Continue();
            return new AddPayeSchemeUsingGGDetailsPage(context);
        }

        public AddAPAYESchemePage CickBackLinkInTheseDetailsAreAlreadyInUsePage()
        {
            NavigateBack();
            return new AddAPAYESchemePage(context);
        }
    }
}
