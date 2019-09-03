using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public abstract class CheckPage : BasePage
    {
        protected override string PageTitle { get; }

        protected abstract By Identifier { get; }

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        public CheckPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }
        public bool IsIndexPageDisplayed()
        {
            return _pageInteractionHelper.IsElementDisplayed(Identifier);
        }
    }
}
