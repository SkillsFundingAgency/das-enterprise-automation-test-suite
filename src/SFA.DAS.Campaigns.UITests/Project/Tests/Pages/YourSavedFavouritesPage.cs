using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class YourSavedFavouritesPage : BasePage
    {
        protected override string PageTitle => "Your saved favourites";

        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By RemoveFromFav(string id) => By.CssSelector($".app-task-list__training-provider-content[href*='{id}/delete']");

        public YourSavedFavouritesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ConfirmRemovalPage RemoveFromFavourites(string courseId)
        {
            _formCompletionHelper.Click(RemoveFromFav(courseId));
            return new ConfirmRemovalPage(_context);
        }
    }
}
