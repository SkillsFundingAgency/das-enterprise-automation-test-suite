using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimApprenticesHomePage : InterimEmployerBasePage
    {
        private readonly ScenarioContext _context;

        protected override string PageTitle => "Apprentices";

        protected override string Linktext => "Apprentices";

        protected By AddAnApprenticeLink => By.LinkText("Add an apprentice");

        public InterimApprenticesHomePage(ScenarioContext context, bool navigate) : this(context, navigate, false) { }

        public InterimApprenticesHomePage(ScenarioContext context, bool navigate, bool gotourl) : base(context, navigate, gotourl) => _context = context;

        public AccessDeniedPage AddAnApprenticeAndRedirectedToAccessDeniedPage()
        {
            formCompletionHelper.ClickElement(AddAnApprenticeLink);
            return new AccessDeniedPage(_context);
        }
    }
}