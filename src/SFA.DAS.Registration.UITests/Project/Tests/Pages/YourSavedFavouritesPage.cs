using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourSavedFavouritesPage : RegistrationBasePage
    {
        protected override string PageTitle => "Your saved favourites";

        public YourSavedFavouritesPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}